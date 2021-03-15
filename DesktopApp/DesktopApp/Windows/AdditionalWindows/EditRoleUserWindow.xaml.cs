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
    /// Interaction logic for EditRoleUserWindow.xaml
    /// </summary>
    public partial class EditRoleUserWindow : Window
    {
        private readonly Users _selectUser;
        public EditRoleUserWindow(Users user)
        {
            InitializeComponent();

            _selectUser = user;
            DataContext = _selectUser;
            Load();
        }

        private void Load()
        {
            try
            {
                ICRoles.ItemsSource = AppData.Context.Roles.ToList();
                CbxOffice.ItemsSource = AppData.Context.Offices.ToList();
            }
            catch (Exception)
            {
                AppData.Message.MessageInfo("There is no connection to the database. Please contact your system administrator.");
            }
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppData.Context.SaveChanges();
                AppData.Message.MessageInfo("Role changed successfully");
                Close();
            }
            catch (Exception)
            {
                AppData.Message.MessageInfo("There is no connection to the database. Please contact your system administrator.");
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ICRoles_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in ICRoles.Items)
            {
                ContentPresenter content = (ContentPresenter)ICRoles.ItemContainerGenerator.ContainerFromItem(item);
                if (item as Roles == _selectUser.Roles)
                    (content.ContentTemplate.FindName("RBtn", content) as RadioButton).IsChecked = true;
            }
        }

        private void RBtn_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton RBtn = sender as RadioButton;
            if (RBtn.IsChecked == true)
                _selectUser.Roles = RBtn.DataContext as Roles;

        }
    }
}
