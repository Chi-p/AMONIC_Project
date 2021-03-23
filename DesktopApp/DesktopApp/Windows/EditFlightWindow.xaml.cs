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
    /// Interaction logic for EditScheduleWindow.xaml
    /// </summary>
    public partial class EditFlightWindow : Window
    {
        private readonly Schedules _schedule;
        public EditFlightWindow(Schedules schedule)
        {
            InitializeComponent();

            _schedule = schedule;
            DataContext = _schedule;

            TbxTimeHours.Text = _schedule.Time.Hours.ToString();
            TbxTimeMinutes.Text = _schedule.Time.Minutes.ToString();
        }

        private void OnlyDigit(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }

        private void TbxTimeMinutes_TextChanged(object sender, TextChangedEventArgs e)
        {
            HoursAndMinutes(TbxTimeMinutes, 59);
        }

        private void TbxTimeHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            HoursAndMinutes(TbxTimeHours, 23);
        }

        private void HoursAndMinutes(TextBox Tbx, int digit)
        {
            if (Tbx != null)
            {
                if (string.IsNullOrWhiteSpace(Tbx.Text))
                {
                    Tbx.Text = "0";
                    Tbx.SelectAll();
                }
                if (int.Parse(Tbx.Text) > digit)
                {
                    Tbx.Text = digit.ToString();
                    Tbx.SelectionStart = Tbx.Text.Length;
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DPDate.SelectedDate == null || string.IsNullOrWhiteSpace(TbxEconomyPrice.Text))
            {
                string error = "Enter data:\n";
                if (DPDate.SelectedDate == null)
                    error += "Date\n";
                if (string.IsNullOrWhiteSpace(TbxEconomyPrice.Text))
                    error += "EconomyPrice\n";

                AppData.Message.MessageError(error);
            }
            else
            {
                _schedule.Time = new TimeSpan(int.Parse(TbxTimeHours.Text), int.Parse(TbxTimeMinutes.Text), 0);

                AppData.Context.SaveChanges();
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TbxEconomyPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text[0] == '.' && TbxEconomyPrice.Text.Contains('.'))
                e.Handled = true;
            else if (e.Text[0] != '.' && !Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}
