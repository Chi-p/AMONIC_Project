using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Entities
{
    public partial class LoginHistories
    {
        public TimeSpan? TimeSpent
        {
            get
            {
                if (LogoutDateTime != null)
                    return Convert.ToDateTime(LogoutDateTime) - LoginDateTime;
                else
                    return null;
            }
        }
    }
}
