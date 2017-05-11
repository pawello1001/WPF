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

namespace ProjektWPF
{
    /// <summary>
    /// Interaction logic for ShowReminderWindow.xaml
    /// </summary>
    public partial class ShowReminderWindow : Window
    {
        public ShowReminderWindow()
        {
            InitializeComponent();
        }

        private void ShowAlarmOk(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowAlarmCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
