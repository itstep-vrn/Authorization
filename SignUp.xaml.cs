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
using PasswordCheck;

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            //TODO Connect to DB
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            input_Login.Clear();
            input_Password.Clear();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены, что хотите закрыть окно авторизации?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void input_Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordCheck = new PasswordCheck.PasswordCheck();
            var password = input_Password.Password;

            passwordCheck.Error += MessageLabel_CheckLength_Error;
            passwordCheck.Success += MessageLabel_CheckLength_Success;
            var checkLength = passwordCheck.CheckLength(password);
            passwordCheck.Error -= MessageLabel_CheckLength_Error;
            passwordCheck.Success -= MessageLabel_CheckLength_Success;

            passwordCheck.Error += MessageLabel_CheckSymbols_Error;
            passwordCheck.Success += MessageLabel_CheckSymbols_Success;
            var checkSymbols = passwordCheck.CheckSymbol(password);
            passwordCheck.Error -= MessageLabel_CheckSymbols_Error;
            passwordCheck.Success -= MessageLabel_CheckSymbols_Success;

            passwordCheck.Error += MessageLabel_CheckAlphabet_Error;
            passwordCheck.Success += MessageLabel_CheckAlphabet_Success;
            var checkAlphabet = passwordCheck.CheckAlphabet(password);
            passwordCheck.Error -= MessageLabel_CheckAlphabet_Error;
            passwordCheck.Success -= MessageLabel_CheckAlphabet_Success;

            if (checkLength && checkSymbols && checkAlphabet)
            {
                input_RepeatPassword.IsEnabled = true;
            }
            else
            {
                input_RepeatPassword.IsEnabled = false;
            }
        }

        private void MessageLabel_CheckLength_Error(string message)
        {
            label_PasswordCheck_Length.Foreground = Brushes.Red;
            label_PasswordCheck_Length.Text = message;
        }
        private void MessageLabel_CheckLength_Success(string message)
        {
            label_PasswordCheck_Length.Foreground = Brushes.Green;
            label_PasswordCheck_Length.Text = message;
        }

        private void MessageLabel_CheckSymbols_Error(string message)
        {
            label_PasswordCheck_Symbols.Foreground = Brushes.Red;
            label_PasswordCheck_Symbols.Text = message;
        }
        private void MessageLabel_CheckSymbols_Success(string message)
        {
            label_PasswordCheck_Symbols.Foreground = Brushes.Green;
            label_PasswordCheck_Symbols.Text = message;
        }

        private void MessageLabel_CheckAlphabet_Error(string message)
        {
            label_PasswordCheck_Alphabet.Foreground = Brushes.Red;
            label_PasswordCheck_Alphabet.Text = message;
        }
        private void MessageLabel_CheckAlphabet_Success(string message)
        {
            label_PasswordCheck_Alphabet.Foreground = Brushes.Green;
            label_PasswordCheck_Alphabet.Text = message;
        }

        private void input_RepeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = input_Password.Password;
            string passwordRepeat = input_RepeatPassword.Password;

            if (passwordRepeat == "")
            {
                label_Password_CheckRepeat.Text = "";
            }
            else if (password == passwordRepeat)
            {
                label_Password_CheckRepeat.Foreground = Brushes.Green;
                label_Password_CheckRepeat.Text = "Пароли совпадают";
                button_SignUp.IsEnabled = true;
            }
            else
            {
                label_Password_CheckRepeat.Foreground = Brushes.Red;
                label_Password_CheckRepeat.Text = "Пароли не совпадают";
                button_SignUp.IsEnabled = false;
            }
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
