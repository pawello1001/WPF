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
        List<User> users;

        AddAdressWindow addAdressWindow;
        AddUserWindow addUserWindow;
        ShowUserWindow showUserWindow;

        public MainWindow()
        {
            addresses = new List<Address>();
            users = new List<User>();
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

        private void AddUserWindow(object sender, RoutedEventArgs e)
        {
            addUserWindow = new AddUserWindow();
            foreach(var item in addresses)
            {
                addUserWindow.addressesComboBox.Items.Add(item.address);
            }
            if(addUserWindow.ShowDialog() == true)
            {
                users.Add(new User()
                {
                    id = users.Count,
                    name = addUserWindow.name,
                    surname = addUserWindow.surname,
                    email = addUserWindow.email,
                    phone = addUserWindow.phone,
                    address = addUserWindow.address                    
                });
            }
            foreach(var item in addresses)
            {
                if(item.address.Equals(addUserWindow.address))
                {
                    item.name = addUserWindow.name + " " + addUserWindow.surname;
                }
            }
            refresh();
        }

        private void DeleteUserWindow(object sender, RoutedEventArgs e)
        {
            if (contactsListBox.SelectedItem != null)
            {
                int index = contactsListBox.SelectedIndex;
                users.RemoveAt(index);
                refresh();
            }
        }

        private void EditUserWindow(object sender, RoutedEventArgs e)
        {
            User user = (User)contactsListBox.SelectedItem;
            addUserWindow = new AddUserWindow();

            addUserWindow.id = user.id;
            addUserWindow.nameBox.Text = user.name;
            addUserWindow.surnameBox.Text = user.surname;
            addUserWindow.emailBox.Text = user.email;
            addUserWindow.phoneBox.Text = user.phone.ToString();
            foreach(var item in addresses)
            {
                addUserWindow.addressesComboBox.Items.Add(item.address);
            }
            if (addUserWindow.ShowDialog() == true)
            {
                foreach (var item in users)
                {
                    if (item.id == addUserWindow.id)
                    {
                        item.name = addUserWindow.name;
                        item.surname = addUserWindow.surname;
                        item.email = addUserWindow.email;
                        item.phone = addUserWindow.phone;
                        item.address = addUserWindow.address;
                    }
                }
            }
            refresh();
        }

        private void ShowUserWindow(object sender, RoutedEventArgs e)
        {
            User user = (User)contactsListBox.SelectedItem;
            showUserWindow = new ShowUserWindow();

            showUserWindow.showUserName.Text = user.name;
            showUserWindow.showUserSurname.Text = user.surname;
            showUserWindow.showUserEmail.Text = user.email;
            showUserWindow.showUserPhone.Text = user.phone.ToString();
            showUserWindow.showUserAddress.Text = user.address;
            showUserWindow.Show();
        }

        private void UserWindowSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contactsListBox.SelectedItem != null)
            {
                deleteContact.IsEnabled = true;
                editContact.IsEnabled = true;
                showContact.IsEnabled = true;
            }
            else
            {
                deleteContact.IsEnabled = false;
                editContact.IsEnabled = false;
                showContact.IsEnabled = false;
            }
        }

        private void AddReminderWindow(object sender, RoutedEventArgs e)
        {
            ReminderWindow window = new ReminderWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        public void refresh()
        {
            addressesListBox.ItemsSource = "";
            addressesListBox.ItemsSource = addresses;
            contactsListBox.ItemsSource = "";
            contactsListBox.ItemsSource = users;
        }

    }
}
