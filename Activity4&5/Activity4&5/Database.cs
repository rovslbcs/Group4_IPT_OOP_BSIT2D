using MySql.Data.MySqlClient;

namespace Activity4_5
{
    class Database
    {
        private static string server = "localhost";
        private static string database = "oop_ipt";
        private static string username = "root";
        private static string password = "";
        private static string connString = $"Server={server};Database={database};User ID={username};Password={password};";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}
