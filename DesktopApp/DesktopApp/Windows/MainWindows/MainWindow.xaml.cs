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

namespace DesktopApp.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsCloseAll = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            AppData.Authorization.Logout(IsCloseAll);

        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.MessageQuestion("Are you sure you want to close this window and logout?") == MessageBoxResult.Yes)
            {
                IsCloseAll = false;
                Close();
            }
        }
    }
}
