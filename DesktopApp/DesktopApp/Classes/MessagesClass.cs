using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopApp.Classes
{
    public class MessagesClass
    {
        public MessageBoxResult MessageError(string message)
        {
            return MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public MessageBoxResult MessageInfo(string message)
        {
            return MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MessageBoxResult MessageWarning(string message)
        {
            return MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public MessageBoxResult MessageQuestion(string message)
        {
            return MessageBox.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public MessageBoxResult MessageCatch()
        {
            return MessageBox.Show("There is no connection to the database. Please contact your system administrator", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
