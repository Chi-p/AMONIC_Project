using DesktopApp.Entities;
using DesktopApp.Windows;
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
        private List<Tickets> _ticketsList = new List<Tickets>();
        private List<Tickets> _passengersList = new List<Tickets>();
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
            try
            {
                GBOutbound.DataContext = _outbound;
                BtnRemovePassanger.IsEnabled = BtnConfirm.IsEnabled = false;
                CbxPassportCountry.ItemsSource = AppData.Context.Countries.ToList();

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
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }

        private void Update()
        {
            try
            {
                DGPassangers.ItemsSource = null;
                DGPassangers.ItemsSource = _passengersList;
                BtnRemovePassanger.IsEnabled = false;
                Clear();
            }
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }

        private void OnlyDigit(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }

        private void BtnAddPassanger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TbxFirstName.Text) || string.IsNullOrWhiteSpace(TbxLastName.Text) ||
                       string.IsNullOrWhiteSpace(TbxPassportNumber.Text) || string.IsNullOrWhiteSpace(TbxPhone.Text) ||
                       DPBirthdate.SelectedDate == null || CbxPassportCountry.SelectedItem == null)
                {
                    string error = "Enter data:\n";

                    if (string.IsNullOrWhiteSpace(TbxFirstName.Text))
                        error += "First name\n";
                    if (string.IsNullOrWhiteSpace(TbxLastName.Text))
                        error += "Last name\n";
                    if (string.IsNullOrWhiteSpace(TbxPassportNumber.Text))
                        error += "Passport number\n";
                    if (CbxPassportCountry.SelectedItem == null)
                        error += "Passport country\n";
                    if (DPBirthdate.SelectedDate == null)
                        error += "Birthdate\n";
                    if (string.IsNullOrWhiteSpace(TbxPhone.Text))
                        error += "Phone\n";

                    AppData.Message.MessageError(error);
                }
                else if (_passengersList.FirstOrDefault(i =>
                i.PassportNumber == TbxPassportNumber.Text || i.Phone == TbxPhone.Text) != null)
                {
                    AppData.Message.MessageError("You have already added a user with this passport number or phone!");
                }
                else
                {
                    string outboundCode = GenerateCode();

                    if (string.IsNullOrWhiteSpace(outboundCode))
                    {
                        AppData.Message.MessageError("Couldn't generate the code. Try again");
                        return;
                    }

                    Tickets outboundTicket = CreateTicket(_outbound, outboundCode);

                    _ticketsList.Add(outboundTicket);
                    _passengersList.Add(outboundTicket);

                    if (_return != null)
                    {
                        string returnCode = GenerateCode();

                        if (string.IsNullOrWhiteSpace(returnCode))
                        {
                            AppData.Message.MessageError("Couldn't generate the code. Try again");
                            _ticketsList.Remove(outboundTicket);
                            _passengersList.Remove(outboundTicket);
                            return;
                        }

                        Tickets returnTicket = CreateTicket(_return, returnCode);

                        _ticketsList.Add(returnTicket);
                    }

                    if (_passengersList.Count == _passengers)
                    {
                        BtnAddPassanger.IsEnabled = false;
                        BtnConfirm.IsEnabled = true;
                    }

                    Update();
                }
            }
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }

        private Tickets CreateTicket(Schedules schedule, string returnCode)
        {
            return new Tickets
            {
                Users = AppData.Context.Users.ToList().FirstOrDefault(),
                Schedules = schedule,
                CabinTypes = AppData.Context.CabinTypes.ToList().FirstOrDefault(i => i.Name == schedule.CabinPriceName),
                Firstname = TbxFirstName.Text,
                Lastname = TbxLastName.Text,
                Phone = TbxPhone.Text,
                PassportNumber = TbxPassportNumber.Text,
                Countries = CbxPassportCountry.SelectedItem as Countries,
                Birthdate = DPBirthdate.SelectedDate.Value.Date,
                BookingReference = returnCode,
                Confirmed = true
            };
        }

        private string GenerateCode()
        {
            try
            {
                string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string digits = "1234567890";
                string result = "";
                bool restart = false;

                do
                {
                    result = "";
                    restart = false;
                    Random rand = new Random();

                    for (int i = 0; i < 6; i++)
                    {
                        switch (rand.Next(1, 3))
                        {
                            case 1:
                                result += letters[rand.Next(letters.Length)];
                                break;
                            case 2:
                                result += digits[rand.Next(digits.Length)];
                                break;
                        }
                    }

                    foreach (var item in AppData.Context.Tickets.ToList())
                    {
                        if (item.BookingReference == result || _ticketsList.Where(i => i.BookingReference == result).ToList().Count > 0)
                        {
                            restart = true;
                        }
                    }

                }
                while (restart);

                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.MessageQuestion("Are you sure you want to clear the passenger creation?") == MessageBoxResult.Yes)
                Clear();
        }

        private void Clear()
        {
            TbxFirstName.Text = TbxLastName.Text = TbxPhone.Text = TbxPassportNumber.Text = "";
            CbxPassportCountry.SelectedItem = null;
            DPBirthdate.SelectedDate = null;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.MessageQuestion
                ("Are you sure you want to stop confirming your booking and return to the search page?") == MessageBoxResult.Yes)
                AppData.MainFrame.GoBack();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (_passengersList.Count != _passengers)
            {
                AppData.Message.MessageInfo($"You didn't add all the passengers. Required quantity: {_passengers}");
            }
            else
            {
                try
                {
                    BillingConfirmWindow window = new BillingConfirmWindow(_ticketsList)
                    {
                        Owner = MainWindow.GetWindow(Application.Current.MainWindow)
                    };
                    window.ShowDialog();

                    if (AppData.IsAddTickets)
                        AppData.MainFrame.Navigate(new SearchForFlightsPage());

                    AppData.IsAddTickets = false;
                }
                catch (Exception)
                {
                    AppData.Message.MessageNotConnect();
                }
            }
        }

        private void BtnRemovePassanger_Click(object sender, RoutedEventArgs e)
        {
            if (DGPassangers.SelectedItem == null)
            {
                AppData.Message.MessageInfo("First select a row in the table");
            }
            else
            {
                var passanger = DGPassangers.SelectedItem as Tickets;

                _passengersList.Remove(passanger);
                _ticketsList.Remove(passanger);

                if (_return != null)
                {
                    passanger.Schedules = _return;
                    _ticketsList.Remove(passanger);
                }

                Update();

                BtnAddPassanger.IsEnabled = true;
            }
        }

        private void DGPassangers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnRemovePassanger.IsEnabled = true;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
    }
}
