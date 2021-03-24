using DesktopApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        private string _filePath;

        private int _successRecords = 0;
        private int _duplicateRecords = 0;
        private int _errorRecords = 0;

        private List<Schedules> _schedulesList;
        private List<Routes> _routesList;
        private List<Schedules> _newSchedulesList = new List<Schedules>();

        readonly OpenFileDialog _ofd = new OpenFileDialog
        {
            Filter = "*CSV Files |*.csv"
        };

        public ImportWindow()
        {
            InitializeComponent();
        }

        private void LoadLists()
        {
            try
            {
                AppData.Context.ChangeTracker.Entries<Schedules>().ToList().ForEach(i => i.Reload());
                AppData.Context.ChangeTracker.Entries<Routes>().ToList().ForEach(i => i.Reload());

                _schedulesList = AppData.Context.Schedules.ToList();
                _routesList = AppData.Context.Routes.ToList();
            }
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }

        private void Clear(bool ClearAll)
        {
            TbxFileName.Text = _filePath = "";
            _successRecords = _duplicateRecords = _errorRecords = 0;
            if (ClearAll)
                TbkSuccessRecords.Text = TbkDuplicateRecords.Text = TbkErrorRecords.Text = "";
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_filePath))
            {
                AppData.Message.MessageInfo("First, select the file. To select, click on the text field");
            }
            else
            {
                string[] lines = new string[] { };
                try
                {
                    lines = File.ReadAllLines(_filePath);
                }
                catch (Exception)
                {
                    AppData.Message.MessageError("Error when trying to read the file. Close it or check the path and try again");
                    return;
                }
                LoadLists();
                Clear(true);

                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Count() != 9)
                    {
                        _errorRecords++;
                        continue;
                    }

                    try
                    {
                        var route = _routesList.FirstOrDefault(i =>
                        i.Airports.IATACode == data[4].ToUpper() && i.Airports1.IATACode == data[5].ToUpper());

                        if (route == null)
                        {
                            _errorRecords++;
                            continue;
                        }

                        var schedule = new Schedules
                        {
                            Date = Convert.ToDateTime(data[1]),
                            Time = TimeSpan.Parse(data[2]),
                            FlightNumber = data[3],
                            RouteID = route.ID,
                            AircraftID = Int32.Parse(data[6]),
                            EconomyPrice = decimal.Parse(data[7]),
                            Confirmed = (data[8].ToUpper() == "OK")
                        };

                        var baseSchedule = _schedulesList.FirstOrDefault(i =>
                        i.Date == schedule.Date && i.FlightNumber == schedule.FlightNumber);

                        if (baseSchedule != null)
                        {
                            if (data[0].ToUpper() == "EDIT")
                            {
                                baseSchedule.Confirmed = (data[8].ToUpper() == "OK");
                                baseSchedule.EconomyPrice = decimal.Parse(data[7]);
                                _successRecords++;
                                continue;
                            }
                            else
                            {
                                _duplicateRecords++;
                                continue;
                            }
                        }

                        _newSchedulesList.Add(schedule);
                        _successRecords++;
                    }
                    catch (Exception)
                    {
                        _errorRecords++;
                        continue;
                    }

                }
                TbkSuccessRecords.Text = _successRecords.ToString();
                TbkDuplicateRecords.Text = _duplicateRecords.ToString();
                TbkErrorRecords.Text = _errorRecords.ToString();
                Clear(false);

                AppData.Context.Schedules.AddRange(_newSchedulesList);
                AppData.Context.SaveChanges();
            }
        }

        private void TbxFileName_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _filePath = "";
            if (_ofd.ShowDialog() == true)
            {
                TbxFileName.Text = _filePath = _ofd.FileName;
                TbxFileName.SelectionStart = TbxFileName.Text.Length;
                Rect rect = TbxFileName.GetRectFromCharacterIndex(TbxFileName.Text.Length);
                TbxFileName.ScrollToHorizontalOffset(rect.Right);
            }
        }
    }
}
