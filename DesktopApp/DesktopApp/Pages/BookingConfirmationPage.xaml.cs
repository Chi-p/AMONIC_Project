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
    /// Interaction logic for BookingConfirmationPage.xaml
    /// </summary>
    public partial class BookingConfirmationPage : Page
    {
        private Schedules _outbound;
        private Schedules _return;
        private int _passengers;
        public BookingConfirmationPage(Schedules outbound, Schedules @return, int passengers)
        {
            InitializeComponent();

            _outbound = outbound;
            _return = @return;
            _passengers = passengers;

            Load();
        }

        private void Load()
        {
            GBOutbound.DataContext = _outbound;

            if (_return == null)
            {
                SPReturn.Visibility = Visibility.Collapsed;
                TbkReturnAbsent.Visibility = Visibility.Visible;
                GBReturn.Background = Brushes.LightGray;
            }
            else
            {
                SPReturn.Visibility = Visibility.Visible;
                TbkReturnAbsent.Visibility = Visibility.Collapsed;
                GBReturn.Background = Brushes.White;

                GBReturn.DataContext = _return;
            }

        }

        private void OnlyDigit(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }

        private void BtnAddPassanger_Click(object sender, RoutedEventArgs e)
        {
            AppData.Message.MessageNotFunctional();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.MessageQuestion("Are you sure you want to clear the passenger creation?") == MessageBoxResult.Yes)
            {
                TbxFirstName.Text = TbxLastName.Text = TbxPhone.Text = TbxPassportNumber.Text = "";
                CbxPassportCountry.SelectedItem = null;
                DPBirthdate.SelectedDate = null;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.GoBack();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            AppData.Message.MessageNotFunctional();

        }

        private void BtnRemovePassanger_Click(object sender, RoutedEventArgs e)
        {
            AppData.Message.MessageNotFunctional();
            BtnAddPassanger.IsEnabled = false;
        }

        private void DGPassangers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnAddPassanger.IsEnabled = true;
        }
    }
}
