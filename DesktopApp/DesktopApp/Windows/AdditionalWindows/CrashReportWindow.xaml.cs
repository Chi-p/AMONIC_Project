using DesktopApp.Classes;
using DesktopApp.Entities;
using DesktopApp.Windows.MainWindows;
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

namespace DesktopApp.Windows.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for CrashReportWindow.xaml
    /// </summary>
    public partial class CrashReportWindow : Window
    {
        private readonly LoginHistories _loginHistory;
        bool IsCloseAll = true;

        public CrashReportWindow(LoginHistories loginHistory)
        {
            InitializeComponent();
            _loginHistory = loginHistory;
            DataContext = _loginHistory;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RBtnSoftwareCrash.IsChecked == false && RBtnSystemCrash.IsChecked == false && string.IsNullOrWhiteSpace(TbxReason.Text))
                {
                    AppData.Message.MessageError("Enter data.");
                }
                else if (RBtnSoftwareCrash.IsChecked == false && RBtnSystemCrash.IsChecked == false)
                {
                    AppData.Message.MessageError("Select the type of crash.");
                }
                else if (string.IsNullOrWhiteSpace(TbxReason.Text))
                {
                    AppData.Message.MessageError("Describe the reason of the crash.");
                }
                else
                {
                    _loginHistory.CrashTypeID = RBtnSoftwareCrash.IsChecked == true ? 1 : 2;
                    AppData.Authorization.CreateLoginHistory();

                    AppData.Message.MessageInfo("The reason for the crash was successfully saved. Thank you for your help!");

                    IsCloseAll = false;
                    AppData.Authorization.Login(AppData.CurrentUser.Roles.Title);
                    Close();
                }
            }
            catch (Exception)
            {
                AppData.Message.MessageInfo("There is no connection to the database. Please contact your system administrator.");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsCloseAll == true)
                Application.Current.MainWindow.Close();
        }
    }
}
