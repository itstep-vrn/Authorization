using System;
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

namespace Authorization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string login = "login";
        private string password = "123";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (input_Login.Text == login && input_Password.Password == password)
            {
                MessageBox.Show("Авторизация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Вы ввели неверный логин или пароль.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                input_Login.Clear();
                input_Password.Clear();
            }
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

        private void hyper_SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            Close();
        }

        private void hyper_RestorePassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
