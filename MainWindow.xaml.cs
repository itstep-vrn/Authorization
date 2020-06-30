using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using static Logging.LogToFile;

namespace Authorization
{
    public partial class MainWindow : Window
    {
        //TODO Значение переменных из БД
        private string login;
        private string password;
        private MySqlConnection connection;

        private const string host = "mysql11.hostland.ru";
        private const string database = "host1323541_suptest2";
        private const string port = "3306";
        private const string username = "host1323541_itstep";
        private const string pass = "269f43dc";
        private const string ConnString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + pass;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => Log("info.log", "INFO", "Окно авторизации загружено");
            Closed += (sender, args) => Log("info.log", "INFO", "Окно авторизации закрылось");
            
            connection = new MySqlConnection(ConnString);
            connection.Open();
        }

        private void ButtonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            var checkAccount = false;
            const string sql = "SELECT login, pass FROM Account";
            var command = new MySqlCommand {Connection = connection, CommandText = sql};
            using var result = command.ExecuteReader();
            while (result.Read())
            {
                login = result.GetString(0);
                password = result.GetString(1);
                
                if (InputLogin.Text == login && InputPassword.Password == password)
                {
                    checkAccount = true;
                    break;
                }
                else
                {
                    checkAccount = false;
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
