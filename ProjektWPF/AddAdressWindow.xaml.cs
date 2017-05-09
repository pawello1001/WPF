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
    /// Interaction logic for AddAdressWindow.xaml
    /// </summary>
    public partial class AddAdressWindow : Window
    {
        public int id;
        public string name;
        public string address;

        public AddAdressWindow()
        {
            InitializeComponent();
        }

        private void AddAddressOk(object sender, RoutedEventArgs e)
        {
            this.name = nameTextBox.Text;
            this.address = addressTextBox.Text;
            DialogResult = true;
            this.Close();
        }

        private void AddAddressCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
