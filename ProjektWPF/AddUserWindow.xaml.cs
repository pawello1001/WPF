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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public int id;
        public string name;
        public string surname;
        public string email;
        public Int64 phone;
        public string address;

        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void AddUserOk(object sender, RoutedEventArgs e)
        {
            long number;
            if(nameBox.Text == "" || surnameBox.Text == "" || emailBox.Text == "")
            {
                MessageBox.Show("Wypełnij wszystkie pola");
            }
            else
            {
                this.name = nameBox.Text;
                this.surname = surnameBox.Text;
                this.email = emailBox.Text;
                if (Int64.TryParse(phoneBox.Text, out number) == false)
                {
                    MessageBox.Show("Podaj prawidłowy numer telefonu");
                }
                else
                {
                    this.phone = number;
                    if (addressesComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Nie wybrałeś żadnego adresu");
                    }
                    else
                    {
                        this.address = addressesComboBox.SelectedItem.ToString();
                        DialogResult = true;
                        this.Close();
                    }
                }
            }
        }

        private void AddUserCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
