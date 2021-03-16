using DesktopApp.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace DesktopApp.Pages.UserPages
{
    /// <summary>
    /// Interaction logic for UserMenuPage.xaml
    /// </summary>
    public partial class UserMenuPage : Page
    {
        private readonly DispatcherTimer LockTimer = new DispatcherTimer();
        public UserMenuPage()
        {
            InitializeComponent();

            DataContext = AppData.CurrentUser;
            LockTimer.Interval = new TimeSpan(0, 0, 1);
            LockTimer.Tick += LockTimer_Tick;
            LockTimer.Start();
            TbkTimeSpent.Text = TimeSpent;
        }

        private string TimeSpent
        {
            get
            {
                return "Time spent on system: " + (DateTime.Now - AppData.Context.LoginHistories.ToList().Where
                    (i => i.Users == AppData.CurrentUser).Last().LoginDateTime).ToString(@"hh\:mm\:ss");
            }
        }

        private void LockTimer_Tick(object sender, EventArgs e)
        {
            TbkTimeSpent.Text = TimeSpent;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            LockTimer.Stop();
        }

        private void DGUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
