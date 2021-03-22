using DesktopApp.Entities;
using DesktopApp.Windows.AdditionalWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
            Load();
        }

        /// <summary>
        /// Method of first data loading
        /// </summary>
        private void Load()
        {
            try
            {
                List<Offices> OfficesList = AppData.Context.Offices.ToList();
                OfficesList.Insert(0, new Offices
                {
                    Title = "All offices"
                });

                CbxOffices.ItemsSource = OfficesList;
                CbxOffices.SelectedIndex = 0;
                DGUsers.ItemsSource = AppData.Context.Users.ToList().OrderByDescending(i => i.Active).ThenBy(i => i.RoleID);
            }
            catch (Exception)
            {
                AppData.Message.MessageInfo("There is no connection to the database. Please contact your system administrator.");
            }
        }

        /// <summary>
        /// Data update method
        /// </summary>
        private void Update()
        {
            try
            {
                List<Users> userList = AppData.Context.Users.ToList();

                if (CbxOffices.SelectedIndex > 0)
                    userList = userList.Where(i => i.Offices == CbxOffices.SelectedItem as Offices).ToList();

                DGUsers.ItemsSource = null;
                DGUsers.ItemsSource = userList.OrderByDescending(i => i.Active).ThenBy(i => i.RoleID);
            }
            catch (Exception)
            {
                AppData.Message.MessageInfo("There is no connection to the database. Please contact your system administrator.");
            }
        }

        private void BtnChangeRole_Click(object sender, RoutedEventArgs e)
        {
            if (DGUsers.SelectedItem == null)
            {
                AppData.Message.MessageInfo("Select the user.");
            }
            else
            {
                EditRoleUserWindow window = new EditRoleUserWindow(DGUsers.SelectedItem as Users)
                {
                    Owner = MainWindow.GetWindow(this)
                };
                window.ShowDialog();
                Update();
            }
        }

        private void BtnEnableDisaleLogin_Click(object sender, RoutedEventArgs e)
        {
            if (DGUsers.SelectedItem == null)
            {
                AppData.Message.MessageInfo("Select the user.");
            }
            else
            {
                try
                {
                    Users selectedUser = (DGUsers.SelectedItem as Users);
                    selectedUser.Active = selectedUser.Active == true ? false : true;
                    AppData.Context.SaveChanges();
                    Update();
                }
                catch (Exception)
                {
                    AppData.Message.MessageInfo("There is no connection to the database. Please contact your system administrator.");
                }
            }
        }

        private void CbxOffices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
