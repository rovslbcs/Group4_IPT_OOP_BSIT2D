using System;
using MySql.Data.MySqlClient;

namespace Activity4_5
{
    class Register
    {
        public static void RegisterUser()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (UserExists(username))
            {
                Console.WriteLine("Username already taken!");
                return;
            }

            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO admin (name, username, password) VALUES (@name, @username, @password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int result = cmd.ExecuteNonQuery();
                        Console.WriteLine(result > 0 ? $"You are successfully registered, {name}!" : "Registration Failed.");
                        Menu.ShowMenu(null);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private static bool UserExists(string username)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM admin WHERE username = @username";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
