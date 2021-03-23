using DesktopApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Schedules> schedulesList = new List<Schedules>();
        private Schedules _selectSchedule;

        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Load();
        }

        /// <summary>
        /// Method of first data loading
        /// </summary>
        private void Load()
        {
            try
            {
                List<Airports> airportsList = AppData.Context.Airports.ToList();
                airportsList.Insert(0, new Airports
                {
                    Name = "All airports"
                });
                CbxFrom.ItemsSource = CbxTo.ItemsSource = airportsList;

                foreach (var item in DGFlights.Columns)
                {
                    CbxSort.Items.Add(item.Header.ToString());
                }

                CbxFrom.SelectedIndex = CbxTo.SelectedIndex = CbxSort.SelectedIndex = 0;

                schedulesList = AppData.Context.Schedules.ToList();
                DGFlights.ItemsSource = schedulesList;
            }
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }

        /// <summary>
        /// Data update method
        /// </summary>
        private void Update()
        {
            try
            {
                schedulesList = AppData.Context.Schedules.ToList();

                if (!string.IsNullOrWhiteSpace(TbxFlightNumber.Text))
                    schedulesList = schedulesList.Where(i => i.FlightNumber == TbxFlightNumber.Text).ToList();

                if (DPOutbound.SelectedDate != null)
                    schedulesList = schedulesList.Where(i => i.Date == DPOutbound.SelectedDate).ToList();

                if (CbxFrom.SelectedItem == CbxTo.SelectedItem && CbxFrom.SelectedIndex > 0 && CbxTo.SelectedIndex > 0)
                {
                    AppData.Message.MessageError("Departure and arrival airports can't be the same");
                }
                else
                {
                    if (CbxFrom.SelectedIndex > 0)
                        schedulesList = schedulesList.Where(i => i.Routes.Airports == CbxFrom.SelectedItem as Airports).ToList();

                    if (CbxTo.SelectedIndex > 0)
                        schedulesList = schedulesList.Where(i => i.Routes.Airports1 == CbxTo.SelectedItem as Airports).ToList();
                }

                DGFlights.ItemsSource = null;
                DGFlights.ItemsSource = schedulesList;

                if (CbxSort.SelectedIndex != -1)
                {
                    var column = DGFlights.Columns[CbxSort.SelectedIndex];
                    DGFlights.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, ListSortDirection.Ascending));

                    foreach (var col in DGFlights.Columns)
                        col.SortDirection = null;

                    column.SortDirection = ListSortDirection.Ascending;
                }

                if (_selectSchedule != null)
                {
                    DGFlights.SelectedItem = _selectSchedule;
                    DGFlights.Focus();
                }
            }
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }

        private void BtnChangeConfirmed_Click(object sender, RoutedEventArgs e)
        {
            if (_selectSchedule == null)
            {
                AppData.Message.MessageInfo("First select a row in the table");
            }
            else
            {
                _selectSchedule.Confirmed = !_selectSchedule.Confirmed;
                AppData.Context.SaveChanges();
                _selectSchedule = null;
                Update();
            }
        }

        private void BtnEditFlight_Click(object sender, RoutedEventArgs e)
        {
            if (_selectSchedule == null)
            {
                AppData.Message.MessageInfo("First select a row in the table");
            }
            else
            {
                EditFlightWindow window = new EditFlightWindow(_selectSchedule)
                {
                    Owner = GetWindow(this)
                };
                window.ShowDialog();
                Update();
            }
        }

        private void BtnImportChanges_Click(object sender, RoutedEventArgs e)
        {
            AppData.Message.MessageNotFunctional();
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            CbxFrom.SelectedIndex = CbxTo.SelectedIndex = CbxSort.SelectedIndex = 0;
            DPOutbound.SelectedDate = null;
            TbxFlightNumber.Text = "";
            Update();
        }

        private void DGFlights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGFlights.SelectedItem == null)
            {
                TbkSelect.Visibility = Visibility.Visible;
                SPCancel.Visibility = SPEnable.Visibility = Visibility.Hidden;
                BtnChangeConfirmed.IsEnabled = BtnEditFlight.IsEnabled = false;
            }
            else
            {
                TbkSelect.Visibility = Visibility.Hidden;
                BtnChangeConfirmed.IsEnabled = BtnEditFlight.IsEnabled = true;

                _selectSchedule = DGFlights.SelectedItem as Schedules;
                if (_selectSchedule.Confirmed == true)
                {
                    SPCancel.Visibility = Visibility.Visible;
                    SPEnable.Visibility = Visibility.Hidden;
                }
                else
                {
                    SPCancel.Visibility = Visibility.Hidden;
                    SPEnable.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
