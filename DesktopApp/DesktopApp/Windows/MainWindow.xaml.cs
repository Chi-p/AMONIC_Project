using DesktopApp.Entities;
using DesktopApp.Page;
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
        public MainWindow()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(new ResultsSummaryPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void MIExit_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.MessageQuestion("Are you sure you want to close application?") == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
