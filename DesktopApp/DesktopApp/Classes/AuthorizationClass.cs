using DesktopApp.Entities;
using DesktopApp.Pages.AdminPages;
using DesktopApp.Pages.UserPages;
using DesktopApp.Windows.MainWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopApp.Classes
{
    public class AuthorizationClass
    {

        public void CreateLoginHistory()
        {
            try
            {
                AppData.Context.LoginHistories.Add(new LoginHistories
                {
                    Users = AppData.CurrentUser,
                    LoginDateTime = DateTime.Now
                });
                AppData.Context.SaveChanges();
            }
            catch (Exception)
            {
                AppData.Message.MessageInfo("There is no connection to the database. Please contact your system administrator.");
            }
        }

        public void Logout(bool IsCloseAll)
        {
            try
            {
                AppData.Context.LoginHistories.ToList().Where(i =>
                i.Users == AppData.CurrentUser).Last().LogoutDateTime = DateTime.Now;
                AppData.Context.SaveChanges();

                AppData.CurrentUser = null;

                if (IsCloseAll == true)
                {
                    Application.Current.MainWindow.Close();
                }
                else
                {
                    Application.Current.MainWindow = new AuthorizationWindow();
                    Application.Current.MainWindow.Show();
                }
            }
            catch (Exception)
            {
                AppData.Message.MessageInfo("There is no connection to the database. Please contact your system administrator.");
            }
        }

        public void Login(string role)
        {
            switch (role)
            {
                case "Administrator":
                    new MainWindow(new AdminMenuPage()).Show();
                    break;
                case "User":
                    new MainWindow(new UserMenuPage()).Show();
                    break;
                default:
                    AppData.Message.MessageInfo("The functionality for this role has not yet been implemented.");
                    break;
            }
        }
    }
}
