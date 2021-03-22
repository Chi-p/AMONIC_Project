using DesktopApp.Classes;
using DesktopApp.Entities;
using DesktopApp.Windows.AdditionalWindows;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesktopApp.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
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

        /// <summary>
        /// Event handler for the login lock timer
        /// </summary>
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

        /// <summary>
        /// Event handler for logging in to your account
        /// </summary>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppData.Context.ChangeTracker.Entries<Users>().ToList().ForEach(i => i.Reload());

                if (string.IsNullOrWhiteSpace(TbxUsername.Text) && string.IsNullOrWhiteSpace(PbxPassword.Password))
                {
                    AppData.Message.MessageError("Enter data.");
                }
                else if (string.IsNullOrWhiteSpace(TbxUsername.Text))
                {
                    AppData.Message.MessageError("Enter username.");
                    TbxUsername.Focus();
                }
                else if (string.IsNullOrWhiteSpace(PbxPassword.Password))
                {
                    AppData.Message.MessageError("Enter password.");
                    PbxPassword.Focus();
                }
                else if (AppData.Context.Users.ToList().FirstOrDefault(i => i.Email == TbxUsername.Text) == null)
                {
                    AppData.Message.MessageError("The user doesn't exist. Enter a different username.");
                    TbxUsername.Focus();
                }
                else if (AppData.Context.Users.ToList().FirstOrDefault(i =>
                i.Email == TbxUsername.Text && i.Password == PbxPassword.Password) == null)
                {
                    AppData.Message.MessageError($"The password you entered is incorrect. Attempts left: {--_attemptsCount}");
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
                    AppData.Message.MessageError("You have been disconnected from the system, please contact your administrator.");
                }
                else
                {
                    AppData.CurrentUser = AppData.Context.Users.ToList().FirstOrDefault(i =>
                    i.Email == TbxUsername.Text && i.Password == PbxPassword.Password);

                    if (AppData.CurrentUser.Active == false)
                    {
                        AppData.Message.MessageInfo("You have been disabled from logging in. Contact your system administrator to resolve the issue.");
                        return;
                    }

                    Application.Current.MainWindow.Hide();

                    if (AppData.Context.LoginHistories.ToList()
                        .Where(i => i.Users == AppData.CurrentUser).Count() != 0)
                    {
                        var lastHistory = AppData.Context.LoginHistories.ToList().Where(
                       i => i.Users == AppData.CurrentUser).Last();

                        if (lastHistory.LogoutDateTime == null)
                        {
                            new CrashReportWindow(lastHistory).Show();
                            return;
                        }
                        else
                        {
                            AppData.Authorization.CreateLoginHistory();
                        }
                    }
                    else
                    {
                        AppData.Authorization.CreateLoginHistory();
                    }

                    AppData.Authorization.Login(AppData.CurrentUser.Roles.Title);
                }
            }
            catch (Exception)
            {
                AppData.Message.MessageCatch();
            }
        }

        /// <summary>
        /// Application exit event handler
        /// </summary>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event handler for changing the window visible state
        /// </summary>
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _lockTime = 10;
            _attemptsCount = 3;
            TbxUsername.Text = PbxPassword.Password = "";
        }
    }
}