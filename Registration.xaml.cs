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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public string ViewModel { get; set; }
        public Registration()
        {
            InitializeComponent();
        }
        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel);
        }
        //кнопка зарегистрироваться
        private void button_Registration_Click(object sender, RoutedEventArgs e)
        {
            string[] dataLogin = input_name.Text.Split('@'); // делим строку на две части
            if (dataLogin.Length == 2) // проверяем если у нас две части
            {
                string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                if (data2Login.Length == 2)
                {

                }
                else MessageBox.Show("Укажите логин в форме х@x.x");
            }
            else MessageBox.Show("Укажите логин в форме х@x.x");

            if (input_name.Text.Length > 5)
            {
                if (input_password.Text.Length > 5)
                {
                    if (input_passwordCopy.Text.Length > 5)
                    { }
                    else MessageBox.Show("Повторите пароль");
                }
                else MessageBox.Show("Укажите пароль");
            }
            else MessageBox.Show("Укажите логин");
            if (input_password.Text == input_passwordCopy.Text) // проверка на совпадение паролей
            {
                MessageBox.Show("Пользователь зарегистрирован");
            }
            else MessageBox.Show("Пароли не совподают");
        }
        //возвращаемся назад
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
