using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopApp.Entities
{
    public class AppData
    {
        public static AMONICEntities Context = new AMONICEntities();
        public static Frame MainFrame;
        public static Users CurrentUser;
    }
}
