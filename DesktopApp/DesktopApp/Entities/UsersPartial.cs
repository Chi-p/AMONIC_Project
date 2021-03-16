using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopApp.Entities
{
    public partial class Users
    {
        public string Age
        {
            get
            {
                if (Birthdate == null)
                    return "-";

                int age = DateTime.Now.Year - Birthdate.Value.Year;

                if (DateTime.Now.DayOfYear < Birthdate.Value.DayOfYear)
                    --age;

                return age.ToString();
            }
        }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public int CrashCount
        {
            get
            {
                return AppData.Context.LoginHistories.ToList().Where(i => i.Users == this).Count();
            }
        }

        public TimeSpan? TimeSpent
        {
            get
            {
                var a = AppData.Context.LoginHistories.ToList().Where(i => i.Users == this).Last();
                if (a.LogoutDateTime != null)
                    return Convert.ToDateTime(a.LogoutDateTime) - a.LoginDateTime;
                else
                    return null;
            }
        }

        public Brush Background
        {
            get
            {
                if (Active == false)
                    return Brushes.Red;
                else if (Roles.Title == "Administrator")
                    return Brushes.LightGreen;
                else
                    return Brushes.White;
            }
        }
        public Brush Foreground
        {
            get
            {
                if (Background == Brushes.Red)
                    return Brushes.White;
                else
                    return Brushes.Black;
            }
        }
    }
}
