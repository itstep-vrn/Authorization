using System.Windows;
using System.Windows.Input;
using static Logging.LogToFile;

namespace Authorization
{
    public partial class MainWindow : Window
    {
        private string login;
        private string password;
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => Log("info.log", "INFO", "Окно авторизации загружено");
            Closed += (sender, args) => Log("info.log", "INFO", "Окно авторизации закрылось");
        }

        private void ButtonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            var checkAccount = false;
            const string sql = "SELECT login, pass FROM Account";
            var db = new DBConnection();
            var result = db.SelectQuery(sql);
            while (result.Read())
            {
                login = result.GetString(0);
                password = result.GetString(1);
                
                if (InputLogin.Text == login && InputPassword.Password == password)
                {
                    checkAccount = true;
                    break;
                }
            }
            if (checkAccount)
            {
                MessageBox.Show("Авторизация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Вы ввели неверный логин или пароль.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                InputLogin.Clear();
                InputPassword.Clear();
            }
            db.Close();
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

        private void HyperSignUp_Click(object sender, RoutedEventArgs e)
        {
            var signUp = new SignUp();
            signUp.Show();
            Close();
        }

        private void HyperRestorePassword_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
