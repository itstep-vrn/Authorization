using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static Logging.LogToFile;

namespace Authorization
{
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
            Loaded += (sender, args) => Log("info.log", "INFO", "Окно регистрации загружено");
            Closed += (sender, args) => Log("info.log", "INFO", "Окно регистрации закрылось");
        }

        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            //TODO Connect to DB
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

            passwordCheck.Error += ErrorLog;
            passwordCheck.Success += SuccessLog;

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

        private void ErrorLog(string message)
        {
            Log("error.log", "ERROR", message);
        }

        private void SuccessLog(string message)
        {
            Log("success.log", "SUCCESS", message);
        }
        
        private void InputRepeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = InputPassword.Password;
            string passwordRepeat = InputRepeatPassword.Password;

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
