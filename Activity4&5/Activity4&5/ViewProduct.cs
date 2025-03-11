using MySql.Data.MySqlClient;
using System;

namespace Activity4_5
{
    class ViewProduct
    {
        public static void ViewProductData()
        {
            Console.Clear();
            Console.WriteLine(@"
    .........%%%%%...%%%%%....%%%%...%%%%%...%%..%%...%%%%...%%%%%%..........%%......%%%%%%...%%%%...%%%%%%.........
    .%%%%%%..%%..%%..%%..%%..%%..%%..%%..%%..%%..%%..%%..%%....%%............%%........%%....%%........%%....%%%%%%.
    .........%%%%%...%%%%%...%%..%%..%%..%%..%%..%%..%%........%%............%%........%%.....%%%%.....%%...........
    .%%%%%%..%%......%%..%%..%%..%%..%%..%%..%%..%%..%%..%%....%%............%%........%%........%%....%%....%%%%%%.
    .........%%......%%..%%...%%%%...%%%%%....%%%%....%%%%.....%%............%%%%%%..%%%%%%...%%%%.....%%...........
    ................................................................................................................
");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("| Product ID   | Product Name        | Category        | Price       |");
            Console.WriteLine("-------------------------------------------------------------------------------------");

            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT product_id, product_name, product_category, product_price FROM products";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"| {reader["product_id"],-12} | {reader["product_name"],-19} | {reader["product_category"],-15} | {reader["product_price"],-11} |");
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            
            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
            Console.Clear();
            Menu.ShowMenu(null);
        }
    }
}
