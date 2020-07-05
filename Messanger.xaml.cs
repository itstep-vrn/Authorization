using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для Messanger.xaml
    /// </summary>
    public partial class Messanger : Window
    {
        public Messanger()
        {
            InitializeComponent();
        }

        private void search_textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (search_textbox.Text == "Searching")
            {
                search_textbox.Text = "";
            }
        }

        private void search_textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search_textbox.Text))
            {
                search_textbox.Text = "Searching";
            }
        }

        private void sendMessage_button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sendMessage_button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sendMessage_button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sendMessage_button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void infoProfile_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void settingsProfile_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void favorite_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void notification_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
