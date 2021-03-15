using DesktopApp.Entities;
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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private readonly Users _user = new Users()
        {
            RoleID = 2,
            Active = false
        };

        public AddUserWindow()
        {
            InitializeComponent();

            Load();
            DataContext = _user;
        }

        private void Load()
        {
            CbxOffice.ItemsSource = AppData.Context.Offices.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_user.Email) || string.IsNullOrWhiteSpace(_user.FirstName) || string.IsNullOrWhiteSpace(_user.LastName) 
                || string.IsNullOrWhiteSpace(PbxPassword.Password) || _user.Offices == null || _user.Birthdate == null)
            {
                string error = "Enter data:\n";

                if (string.IsNullOrWhiteSpace(_user.Email))
                    error += "Email\n";
                if (string.IsNullOrWhiteSpace(_user.FirstName))
                    error += "First name\n";
                if (string.IsNullOrWhiteSpace(_user.LastName))
                    error += "Last name\n";
                if (_user.Offices == null)
                    error += "Office\n";
                if (_user.Birthdate == null)
                    error += "Birthdate\n";
                if (string.IsNullOrWhiteSpace(_user.Password))
                    error += "Password\n";

                AppData.Message.MessageError(error);
            }
            else
            {
                _user.Password = PbxPassword.Password;
                AppData.Context.Users.Add(_user);
                AppData.Context.SaveChanges();

                AppData.Message.MessageInfo("User added successfully");
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
