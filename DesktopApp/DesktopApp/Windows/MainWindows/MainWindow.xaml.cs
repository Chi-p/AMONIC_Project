using DesktopApp.Entities;
using DesktopApp.Pages.AdminPages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsCloseAll = true;

        public MainWindow(Page page)
        {
            InitializeComponent();

            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(page);

            if (AppData.CurrentUser.Roles.Title == "User")
                MIAdd.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// Event handler for closing the window
        /// </summary>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            AppData.Authorization.Logout(IsCloseAll);
        }

        /// <summary>
        /// Event handler for adding a new user
        /// </summary>
        private void MIAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow window = new AddUserWindow
            {
                Owner = MainWindow.GetWindow(this)
            };
            window.ShowDialog();
            AppData.MainFrame.Navigate(new AdminMenuPage());
        }

        /// <summary>
        /// Event handler to log out of your account
        /// </summary>
        private void MIExit_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.MessageQuestion("Are you sure you want to close this window and logout?") == MessageBoxResult.Yes)
            {
                IsCloseAll = false;
                Close();
            }
        }

        /// <summary>
        /// Event handler content changes in an frame
        /// </summary>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (AppData.MainFrame.Content is Page page)
            {
                page.Title = "AMONIC Airlines Automation System";
            }
        }
    }
}
