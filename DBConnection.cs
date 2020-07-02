using Logging;
using MySql.Data.MySqlClient;
using static Logging.LogToFile;

namespace Authorization
{
    public class DBConnection
    {
        private MySqlConnection connection;

        private const string host = "mysql11.hostland.ru";
        private const string database = "host1323541_suptest2";
        private const string port = "3306";
        private const string username = "host1323541_itstep";
        private const string pass = "269f43dc";
        private const string ConnString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + pass;

        public DBConnection()
        {
            connection = new MySqlConnection(ConnString);
            connection.Open();
            Log("db.log", "SUCCESS", $"Подключение к {database} на {host} пользователем {username} прошло успешно");
        }

        public MySqlDataReader SelectQuery(string sql)
        {
            var command = new MySqlCommand {Connection = connection, CommandText = sql};
            var result = command.ExecuteReader();
            Log("db.log", "SUCCESS", $"Запрос {sql} выполнен");
            return result;
        }

        public int InsertQuery(string sql)
        {
            var command = new MySqlCommand {Connection = connection, CommandText = sql};
            var result = command.ExecuteNonQuery();
            Log("db.log", "SUCCESS", $"Запрос {sql} выполнен");
            return result;
        }

        public void Close()
        {
            connection.Close();
            Log("db.log", "SUCCESS", $"Подключение к {database} на {host} пользователем {username} закрыто");
        }
    }
}