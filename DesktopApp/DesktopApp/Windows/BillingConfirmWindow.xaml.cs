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

namespace DesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for BillingConfirmWindow.xaml
    /// </summary>
    public partial class BillingConfirmWindow : Window
    {
        private List<Tickets> _ticketsList;
        public BillingConfirmWindow(List<Tickets> ticketsList)
        {
            InitializeComponent();

            _ticketsList = ticketsList;
            TotalAmountCalculate();
        }

        private void TotalAmountCalculate()
        {
            decimal total = 0;

            foreach (var item in _ticketsList)
            {
                total += item.Schedules.CabinPrice;
            }
            TbkTotalAmount.Text = $"${total:N2}";
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnIssue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppData.Context.Tickets.AddRange(_ticketsList);
                AppData.Context.SaveChanges();
                AppData.IsAddTickets = true;
                AppData.Message.MessageInfo("Tickets were successfully added to the database.");
                Close();
            }
            catch (Exception)
            {
                AppData.Message.MessageNotConnect();
            }
        }
    }
}
