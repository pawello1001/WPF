using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProjektWPF
{
    /// <summary>
    /// Interaction logic for Reminder.xaml
    /// </summary>
    public partial class ReminderWindow : Window
    {
        public int id;
        public string title;
        public string description;
        public DateTime date;
        public DateTime hour;

        public ReminderWindow()
        {
            InitializeComponent();
        }

        private void ReminderWindowOk(object sender, RoutedEventArgs e)
        {
            if(titleBox.Text == "" || descriptionBox.Text == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola");
            }
            else
            {
                this.title = titleBox.Text;
                this.description = descriptionBox.Text;
                if(dateBox.SelectedDate == null)
                {
                    MessageBox.Show("Wybierz datę");
                }
                else
                {
                    this.date = (DateTime)dateBox.SelectedDate;
                    if(hourBox.Value == null)
                    {
                        MessageBox.Show("Wybierz godzinę");
                    }
                    else
                    {
                        hour = DateTime.ParseExact(hourBox.Text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                        DialogResult = true;
                        this.Close();
                    }
                }
            }
        }

        private void ReminderWindowCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
