using System;
using MySql.Data.MySqlClient;

namespace Activity4_5
{
    class Login
    {
        public static void LoginUser()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            LoginDB.LoginValidation(username, password);
        }
    }

    class LoginDB
    {
        public static void LoginValidation(string username, string password)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT name FROM admin WHERE username = @username AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object userName = cmd.ExecuteScalar();

                        if (userName != null)
                        {
                            Console.Clear();
                            Console.WriteLine($"Login Successful! Welcome, {userName}!\n");
                            Menu.ShowMenu(userName);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Username or Password.\n");
                            Login.LoginUser();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Error: " + ex.Message);
                }
            }
        }
    }
}