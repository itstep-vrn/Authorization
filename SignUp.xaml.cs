using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using static Logging.LogToFile;

namespace Authorization
{
    public partial class SignUp : Window
    {
        private MySqlConnection connection;

        private const string host = "mysql11.hostland.ru";
        private const string database = "host1323541_suptest2";
        private const string port = "3306";
        private const string username = "host1323541_itstep";
        private const string pass = "269f43dc";
        private const string ConnString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + pass;
        
        public SignUp()
        {
            InitializeComponent();
            Loaded += (sender, args) => Log("info.log", "INFO", "Окно регистрации загружено");
            Closed += (sender, args) => Log("info.log", "INFO", "Окно регистрации закрылось");
            
            connection = new MySqlConnection(ConnString);
            connection.Open();
        }

        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            var pass = InputPassword.Password;
            var login = InputLogin.Text;
            var sql = $"INSERT INTO Account (login, pass) VALUES ('{login}', '{pass}')";
            var command = new MySqlCommand {Connection = connection, CommandText = sql};
            var result = command.ExecuteNonQuery();
            if (result == 0)
            {
                MessageBox.Show("Регистрация не удалась.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Регистрация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            InputLogin.Clear();
            InputPassword.Clear();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены, что хотите закрыть окно авторизации?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void InputPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordCheck = new PasswordCheck.PasswordCheck();
            var password = InputPassword.Password;

            passwordCheck.Error += (string message) => Log("error.log", "ERROR", message);
            passwordCheck.Success += (string message) => Log("success.log", "SUCCESS", message);;

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
                InputRepeatPassword.IsEnabled = true;
            }
            else
            {
                InputRepeatPassword.IsEnabled = false;
            }
        }

        private void MessageLabel_CheckLength_Error(string message)
        {
            LabelPasswordCheckLength.Foreground = Brushes.Red;
            LabelPasswordCheckLength.Text = message;
        }
        private void MessageLabel_CheckLength_Success(string message)
        {
            LabelPasswordCheckLength.Foreground = Brushes.Green;
            LabelPasswordCheckLength.Text = message;
        }

        private void MessageLabel_CheckSymbols_Error(string message)
        {
            LabelPasswordCheckSymbols.Foreground = Brushes.Red;
            LabelPasswordCheckSymbols.Text = message;
        }
        private void MessageLabel_CheckSymbols_Success(string message)
        {
            LabelPasswordCheckSymbols.Foreground = Brushes.Green;
            LabelPasswordCheckSymbols.Text = message;
        }

        private void MessageLabel_CheckAlphabet_Error(string message)
        {
            LabelPasswordCheckAlphabet.Foreground = Brushes.Red;
            LabelPasswordCheckAlphabet.Text = message;
        }
        private void MessageLabel_CheckAlphabet_Success(string message)
        {
            LabelPasswordCheckAlphabet.Foreground = Brushes.Green;
            LabelPasswordCheckAlphabet.Text = message;
        }

        private void InputRepeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var password = InputPassword.Password;
            var passwordRepeat = InputRepeatPassword.Password;

            if (passwordRepeat == "")
            {
                LabelPasswordCheckRepeat.Text = "";
            }
            else if (password == passwordRepeat)
            {
                LabelPasswordCheckRepeat.Foreground = Brushes.Green;
                LabelPasswordCheckRepeat.Text = "Пароли совпадают";
                ButtonSignUp.IsEnabled = true;
            }
            else
            {
                LabelPasswordCheckRepeat.Foreground = Brushes.Red;
                LabelPasswordCheckRepeat.Text = "Пароли не совпадают";
                ButtonSignUp.IsEnabled = false;
            }
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
