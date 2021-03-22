using DesktopApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Schedules> schedulesList = new List<Schedules>();
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            try
            {
                schedulesList = AppData.Context.Schedules.ToList();
                CbxFrom.ItemsSource = CbxTo.ItemsSource = AppData.Context.Airports.ToList();
                DGFlights.ItemsSource = schedulesList;
            }
            catch (Exception)
            {
                AppData.Message.MessageCatch();
            }
        }

        private void BtnCancelFlight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditFlight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnImportChanges_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                schedulesList = AppData.Context.Schedules.ToList();

                if (!string.IsNullOrWhiteSpace(TbxFlightNumber.Text))
                    schedulesList = schedulesList.ToList().Where(i => i.FlightNumber == TbxFlightNumber.Text).ToList();



            }
            catch (Exception)
            {
                AppData.Message.MessageCatch();
            }
        }
    }
}
