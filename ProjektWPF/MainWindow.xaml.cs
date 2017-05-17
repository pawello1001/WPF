using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ProjektWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Address> addresses;
        List<User> users;
        List<Alarm> alarms;
        List<Thread> threads;

        AddAdressWindow addAdressWindow;
        AddUserWindow addUserWindow;
        ShowUserWindow showUserWindow;
        ReminderWindow reminderWindow;
        ShowReminderWindow showReminderWindow;
        NotificationWindow notificationWindow;

        Alarm alarm;

        public MainWindow()
        {
            addresses = new List<Address>();
            users = new List<User>();
            alarms = new List<Alarm>();
            threads = new List<Thread>();
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
                foreach (var item in addresses)
                {
                    if (item.address.Equals(addUserWindow.address))
                    {
                        item.name = addUserWindow.name + " " + addUserWindow.surname;
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
            alarm = new Alarm();
            reminderWindow = new ReminderWindow();
            if(reminderWindow.ShowDialog() == true)
            {
                alarm.id = alarms.Count;
                alarm.title = reminderWindow.title;
                alarm.description = reminderWindow.description;
                alarm.date = reminderWindow.date;
                alarm.hour = reminderWindow.hour;

                alarms.Add(alarm);

                setAlarm();
            }
            refresh();
        }

        private void DeleteReminderWindow(object sender, RoutedEventArgs e)
        {
            if (notificationListBox.SelectedItem != null)
            {
                int index = notificationListBox.SelectedIndex;
                alarms.RemoveAt(index);
                setAlarm();
                refresh();
            }
        }

        private void EditReminderWindow(object sender, RoutedEventArgs e)
        {
            Alarm alarm = (Alarm)notificationListBox.SelectedItem;
            reminderWindow = new ReminderWindow();

            reminderWindow.id = alarm.id;
            reminderWindow.titleBox.Text = alarm.title;
            reminderWindow.descriptionBox.Text = alarm.description;
            reminderWindow.dateBox.SelectedDate = alarm.date.Date;
            reminderWindow.hourBox.Value = alarm.hour;

            if (reminderWindow.ShowDialog() == true)
            {
                foreach (var item in alarms)
                {
                    if (item.id == reminderWindow.id)
                    {
                        item.title = reminderWindow.title;
                        item.description = reminderWindow.description;
                        item.date = reminderWindow.date;
                        item.hour = reminderWindow.hour;
                    }
                }
            }
            setAlarm();
            refresh();
        }

        private void ShowReminderWindow(object sender, RoutedEventArgs e)
        {
            Alarm alarm = (Alarm)notificationListBox.SelectedItem;
            showReminderWindow = new ShowReminderWindow();

            showReminderWindow.showAlarmTitle.Text = alarm.title;
            showReminderWindow.showAlarmDescription.Text = alarm.description;
            showReminderWindow.showAlarmDate.Text = alarm.date.Date.ToShortDateString();
            showReminderWindow.showAlarmHour.Text = alarm.hour.ToShortTimeString();
            showReminderWindow.Show();
        }

        private void ReminderWindowSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (notificationListBox.SelectedItem != null)
            {
                deleteNotification.IsEnabled = true;
                editNotification.IsEnabled = true;
                previewNotification.IsEnabled = true;
            }
            else
            {
                deleteNotification.IsEnabled = false;
                editNotification.IsEnabled = false;
                previewNotification.IsEnabled = false;
            }
        }

        public void refresh()
        {
            addressesListBox.ItemsSource = "";
            addressesListBox.ItemsSource = addresses;
            contactsListBox.ItemsSource = "";
            contactsListBox.ItemsSource = users;
            notificationListBox.ItemsSource = "";
            notificationListBox.ItemsSource = alarms;
        }

        public void setAlarm()
        {
            if(threads.Any())
            {
                foreach (var item in threads)
                {
                    item.Abort();
                }
                threads.Clear();
            }
            if(alarms.Any())
            {
                DateTime hour = alarms.Min(item => item.hour);
                foreach (var item in alarms)
                {
                    if (item.hour.Equals(hour))
                    {
                        Thread thread = new Thread(new ThreadStart(addAlarm));
                        threads.Add(thread);
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                    }
                }
            }
            
            refresh();
        }

        public void addAlarm()
        {
            int i = 0;
            while (true)
            {
                if (Convert.ToInt16(DateTime.Now.ToString("HH")) == this.alarm.hour.Hour && Convert.ToInt16(DateTime.Now.ToString("mm")) == this.alarm.hour.Minute && Convert.ToInt16(DateTime.Now.ToString("ss")) == this.alarm.hour.Second && DateTime.Today == this.alarm.date)
                {
                    if(i == 0)
                    {
                        notificationWindow = new NotificationWindow();
                        notificationWindow.ShowDialog();
                        i++;
                        if (notificationWindow.DialogResult == true)
                        {
                            i = 0;
                            alarms.Remove(alarm);
                            Thread.CurrentThread.Abort();
                            break;
                        }
                    }   
                }
                else continue;
                Thread.Sleep(1000);
            }
        }
    }
}
