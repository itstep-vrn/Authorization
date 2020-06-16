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


            if (input_name.Text.Length > 5)
            {
                string[] dataLogin = input_name.Text.Split('@'); // делим строку на две части
                if (dataLogin.Length == 2) // проверяем если у нас две части
                {
                    string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                    if (data2Login.Length == 2)
                    {

                    } else MessageBox.Show("Укажите логин в форме xxх@xxx.xx");
                } else MessageBox.Show("Укажите логин в форме xxх@xxx.xx");
                if (input_password.Text.Length > 6)
                {
                    bool english = true; // английская раскладка
                    bool symbol = false; // символ
                    bool number = false; // цифра

                    for (int i = 0; i < input_password.Text.Length; i++) // перебираем символы
                    {
                        if (input_password.Text[i] >= 'А' && input_password.Text[i] <= 'Z') english = false;
                        if (input_password.Text[i] >= '0' && input_password.Text[i] <= '9') number = true; // если цифры
                        if (input_password.Text[i] == '_' || input_password.Text[i] == '-' || input_password.Text[i] == '!') symbol = true; // если символ
                    }
                    if (!english)
                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                    else if (!symbol)
                        MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                    else if (!number)
                        MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                    if (english && symbol && number) // проверяем соответствие
                    {
                    }
                    else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                    if (input_passwordCopy.Text.Length > 6)
                    {
                        if (input_password.Text == input_passwordCopy.Text) // проверка на совпадение паролей
                        {
                            MessageBox.Show("Пользователь зарегистрирован");
                        }
                        else MessageBox.Show("Пароли не совподают");   //возвращаемся назад
                    }
                    else MessageBox.Show("Повторите пароль");
                }
                else MessageBox.Show("Укажите пароль");
            }
            else MessageBox.Show("Укажите логин");
        }
        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
