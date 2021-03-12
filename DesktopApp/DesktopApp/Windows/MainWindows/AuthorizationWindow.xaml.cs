using DesktopApp.Classes;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesktopApp.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private readonly MessagesClass Message = new MessagesClass();
        private int _attemptsCount = 3;
        private int _lockTime = 10;
        private readonly DispatcherTimer LockTimer = new DispatcherTimer();
        public AuthorizationWindow()
        {
            InitializeComponent();
            TbxUsername.Focus();
            LockTimer.Interval = new TimeSpan(0, 0, 1);
            LockTimer.Tick += LockTimer_Tick;
        }

        private void LockTimer_Tick(object sender, EventArgs e)
        {
            TbkLockMessage.Text = $"Account has been locked. Please try again in {--_lockTime} seconds.";

            if (_lockTime <= -1)
            {
                _lockTime = 10;
                _attemptsCount = 3;
                BtnLogin.IsEnabled = true;
                TbkLockMessage.Visibility = Visibility.Hidden;
                LockTimer.Stop();
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(TbxUsername.Text) && string.IsNullOrWhiteSpace(PbxPassword.Password))
                {
                    Message.MessageError("Enter data.");
                }
                else if (string.IsNullOrWhiteSpace(TbxUsername.Text))
                {
                    Message.MessageError("Enter username.");
                    TbxUsername.Focus();
                }
                else if (string.IsNullOrWhiteSpace(PbxPassword.Password))
                {
                    Message.MessageError("Enter password.");
                    PbxPassword.Focus();
                }
                else if (AppData.Context.Users.ToList().FirstOrDefault(i => i.Email == TbxUsername.Text) == null)
                {
                    Message.MessageError("The user doesn't exist. Enter a different username.");
                    TbxUsername.Focus();
                }
                else if (AppData.Context.Users.ToList().FirstOrDefault(i =>
                i.Email == TbxUsername.Text && i.Password == PbxPassword.Password) == null)
                {
                    Message.MessageError($"The password you entered is incorrect. Attempts left: {--_attemptsCount}");
                    PbxPassword.Focus();

                    if (_attemptsCount <= 0)
                    {
                        LockTimer.Start();
                        BtnLogin.IsEnabled = false;
                        TbkLockMessage.Visibility = Visibility.Visible;
                        TbkLockMessage.Text = $"Account has been locked. Please try again in 10 seconds.";
                    }
                }
                else if (AppData.Context.Users.ToList().FirstOrDefault(i =>
                i.Email == TbxUsername.Text && i.Password == PbxPassword.Password).Active == null)
                {
                    Message.MessageError("You have been disconnected from the system, please contact your administrator.");
                }
                else
                {
                    AppData.CurrentUser = AppData.Context.Users.ToList().FirstOrDefault(i =>
                    i.Email == TbxUsername.Text && i.Password == PbxPassword.Password);

                    Application.Current.MainWindow.Hide();
                    switch (AppData.CurrentUser.Roles.Title)
                    {
                        case "Administrator":
                            new MainWindow().Show();
                            break;
                        case "User":
                            new MainWindow().Show();
                            break;
                        default:
                            Message.MessageInfo("The functionality for this role has not yet been implemented.");
                            break;
                    }
                }
            }
            catch (Exception)
            {
                Message.MessageError("There is no connection to the database. Please contact your system administrator.");
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
