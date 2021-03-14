using DesktopApp.Entities;
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
            AppData.Context.LoginHistories.Add(new LoginHistories
            {
                Users = AppData.CurrentUser,
                LoginDateTime = DateTime.Now
            });
            AppData.Context.SaveChanges();
        }

        public void Logout(bool IsCloseAll)
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
    }
}
