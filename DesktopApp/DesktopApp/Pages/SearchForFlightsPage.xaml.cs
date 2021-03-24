using DesktopApp.Entities;
using System;
using System.Collections.Generic;
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

namespace DesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for SearchForFlightsPage.xaml
    /// </summary>
    public partial class SearchForFlightsPage : Page
    {
        private List<Schedules> _outboundList = new List<Schedules>();
        private List<Schedules> _returnList = new List<Schedules>();

        public SearchForFlightsPage()
        {
            InitializeComponent();

            Load();
        }

        private void Load()
        {
            try
            {
                AppData.Context.ChangeTracker.Entries<Schedules>().ToList().ForEach(i => i.Reload());
                AppData.Context.ChangeTracker.Entries<Airports>().ToList().ForEach(i => i.Reload());
                AppData.Context.ChangeTracker.Entries<CabinTypes>().ToList().ForEach(i => i.Reload());

                CbxFrom.ItemsSource = CbxTo.ItemsSource = CbxCabinType.ItemsSource = null;

                GridReturn.Visibility = Visibility.Hidden;
                RBtnOneway.IsChecked = true;

                CbxFrom.ItemsSource = CbxTo.ItemsSource = AppData.Context.Airports.ToList();
                CbxCabinType.ItemsSource = AppData.Context.CabinTypes.ToList();
                CbxCabinType.SelectedIndex = 0;
            }
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }

        private void ChBxOutbound_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ChBxReturn_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnlyDigit(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }

        private void BtnBookFlight_Click(object sender, RoutedEventArgs e)
        {
            AppData.Message.MessageNotFunctional();
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            if (CbxFrom.SelectedItem == null || CbxTo.SelectedItem == null || DPOutbound.SelectedDate == null
                || (RBtnReturn.IsChecked == true && DPReturn.SelectedDate == null))
            {
                string error = "Select parameters:\n";
                if (CbxFrom.SelectedItem == null)
                    error += "Departure airport\n";
                if (CbxTo.SelectedItem == null)
                    error += "Arrival airport\n";
                if (DPOutbound.SelectedDate == null)
                    error += "Outbound date\n";
                if (RBtnReturn.IsChecked == true && DPReturn.SelectedDate == null)
                    error += "Return date";

                AppData.Message.MessageError(error);
            }
            else if (CbxFrom.SelectedItem == CbxTo.SelectedItem)
            {
                AppData.Message.MessageError("Departure and arrival airports can't be the same");
            }
            else if (DPOutbound.SelectedDate == DPReturn.SelectedDate)
            {
                AppData.Message.MessageError("Outbound and return dates can't be the same");
            }
            else if (DPOutbound.SelectedDate >= DPReturn.SelectedDate)
            {
                AppData.Message.MessageError("The return date cannot be earlier than the outbound date");
            }
            else
            {
                Update();
            }
        }

        private void Update()
        {
            try
            {
                _outboundList = AppData.Context.Schedules.ToList();
                _returnList = AppData.Context.Schedules.ToList();

                DGOutbound.ItemsSource = DGReturn.ItemsSource = null;

                _outboundList = _outboundList.Where(i => i.Routes.Airports == CbxFrom.SelectedItem as Airports
                && i.Routes.Airports1 == CbxTo.SelectedItem as Airports).ToList();

                if (ChBxOutbound.IsChecked == true)
                    _outboundList = _outboundList.Where(i => i.Date >= DPOutbound.SelectedDate.Value.AddDays(-3)
                    && i.Date <= DPOutbound.SelectedDate.Value.AddDays(3)).ToList();
                else
                    _outboundList = _outboundList.Where(i => i.Date == DPOutbound.SelectedDate).ToList();
               
                if (RBtnReturn.IsChecked == true)
                {
                    GridReturn.Visibility = Visibility.Visible;

                    _returnList = _returnList.Where(i => i.Routes.Airports == CbxTo.SelectedItem as Airports
                    && i.Routes.Airports1 == CbxFrom.SelectedItem as Airports).ToList();

                    if (ChBxReturn.IsChecked == true)
                        _returnList = _returnList.Where(i => i.Date >= DPReturn.SelectedDate.Value.AddDays(-3)
                        && i.Date <= DPReturn.SelectedDate.Value.AddDays(3)).ToList();
                    else
                        _returnList = _returnList.Where(i => i.Date == DPReturn.SelectedDate).ToList();

                    foreach (var item in _outboundList)
                        SetCabinPrice(item);

                    DGReturn.ItemsSource = _returnList;
                }
                else
                {
                    GridReturn.Visibility = Visibility.Hidden;
                }

                foreach (var item in _outboundList)
                    SetCabinPrice(item);

                DGOutbound.ItemsSource = _outboundList;
            }
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }

        private void SetCabinPrice(Schedules item)
        {
            switch (CbxCabinType.Text)
            {
                case "Economy":
                    item.CabinPrice = $"${item.EconomyPrice:N2}";
                    break;
                case "Business":
                    item.CabinPrice = $"${item.EconomyPrice * (decimal)1.35:N2}";
                    break;
                case "First Class":
                    item.CabinPrice = $"${item.EconomyPrice * (decimal)1.35 * (decimal)1.3:N2}";
                    break;
                default:
                    item.CabinPrice = "-";
                    break;
            }
        }

        private void RBtnOneway_Checked(object sender, RoutedEventArgs e)
        {
            if (RBtnOneway.IsChecked == true)
                DPReturn.IsEnabled = false;
            else
                DPReturn.IsEnabled = true;
        }
    }
}
