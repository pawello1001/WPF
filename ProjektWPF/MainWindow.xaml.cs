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

namespace ProjektWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Address> addresses;
        AddAdressWindow addAdressWindow;

        public MainWindow()
        {
            addresses = new List<Address>();
            InitializeComponent();
        }

        private void NotificationWindow(object sender, RoutedEventArgs e)
        {
            NotificationWindow window = new NotificationWindow();
            window.Show();
        }

        private void AddAdressWindow(object sender, RoutedEventArgs e)
        {
            addAdressWindow = new AddAdressWindow();
            if(addAdressWindow.ShowDialog() == true)
            {
                addresses.Add(new Address()
                {
                    id = addresses.Count,
                    name = addAdressWindow.name,
                    address = addAdressWindow.address   
                });
            }
            refresh();
        }

        private void DeleteAddressWindow(object sender, RoutedEventArgs e)
        {
            if(addressesListBox.SelectedItem != null)
            {
                int index = addressesListBox.SelectedIndex;
                addresses.RemoveAt(index);
                refresh();
            }
        }

        private void EditAddressWindow(object sender, RoutedEventArgs e)
        {
            Address address = (Address)addressesListBox.SelectedItem;
            addAdressWindow = new AddAdressWindow();

            addAdressWindow.id = address.id;
            addAdressWindow.nameTextBox.Text = address.name;
            addAdressWindow.addressTextBox.Text = address.address;

            if(addAdressWindow.ShowDialog() == true)
            {
                foreach(var item in addresses)
                {
                    if(item.id == addAdressWindow.id)
                    {
                        item.name = addAdressWindow.name;
                        item.address = addAdressWindow.address;
                    }
                }
            }
            refresh();
        }

        private void AddressWindowSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(addressesListBox.SelectedItem != null)
            {
                deleteAddressButton.IsEnabled = true;
                editAddressButton.IsEnabled = true;
            }
            else
            {
                deleteAddressButton.IsEnabled = false;
                editAddressButton.IsEnabled = false;
            }
        }

        private void AddReminderWindow(object sender, RoutedEventArgs e)
        {
            ReminderWindow window = new ReminderWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void AddUserWindow(object sender, RoutedEventArgs e)
        {
            AddUserWindow window = new ProjektWPF.AddUserWindow();
            window.Show();
        }

        public void refresh()
        {
            addressesListBox.ItemsSource = "";
            addressesListBox.ItemsSource = addresses;
        }

    }
}
