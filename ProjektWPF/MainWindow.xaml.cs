﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NotificationWindow(object sender, RoutedEventArgs e)
        {
            NotificationWindow window = new NotificationWindow();
            window.Show();
        }

        private void AddAdressWindow(object sender, RoutedEventArgs e)
        {
            AddAdressWindow window = new AddAdressWindow();
            window.Show();
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
    }
}
