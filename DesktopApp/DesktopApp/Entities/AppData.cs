using DesktopApp.Classes;
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
        /// <summary>
        /// Entity to interact with the database
        /// </summary>
        public static AmonicEntities Context = new AmonicEntities();
        /// <summary>
        /// Frame for displaying the page in the window
        /// </summary>
        public static Frame MainFrame;
        /// <summary>
        /// User saved at login
        /// </summary>
        public static Users CurrentUser;
        /// <summary>
        /// Message class
        /// </summary>
        public static MessagesClass Message = new MessagesClass();

        public static bool IsAddTickets = false;
    }
}
