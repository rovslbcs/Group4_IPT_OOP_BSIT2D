using MySql.Data.MySqlClient;
using System;

namespace Activity4_5
{
    class InsertProduct
    {
        public static void InsertProductData()
        {
            InsertProductDB productDB = new InsertProductDB();
            bool continueInserting;

            do
            {
                Console.Clear();
                Console.WriteLine(@"

         ________  ___   __    ______   ______   ______   _________   ______   ________   _________  ________      
        /_______/\/__/\ /__/\ /_____/\ /_____/\ /_____/\ /________/\ /_____/\ /_______/\ /________/\/_______/\     
        \__.::._\/\::\_\\  \ \\::::_\/_\::::_\/_\:::_ \ \\__.::.__\/ \:::_ \ \\::: _  \ \\__.::.__\/\::: _  \ \    
           \::\ \  \:. `-\  \ \\:\/___/\\:\/___/\\:(_) ) )_ \::\ \    \:\ \ \ \\::(_)  \ \  \::\ \   \::(_)  \ \   
           _\::\ \__\:. _    \ \\_::._\:\\::___\/_\: __ `\ \ \::\ \    \:\ \ \ \\:: __  \ \  \::\ \   \:: __  \ \  
          /__\::\__/\\. \`-\  \ \ /____\:\\:\____/\\ \ `\ \ \ \::\ \    \:\/.:| |\:.\ \  \ \  \::\ \   \:.\ \  \ \ 
          \________\/ \__\/ \__\/ \_____\/ \_____\/ \_\/ \_\/  \__\/     \____/_/ \__\/\__\/   \__\/    \__\/\__\/ 
                                                                       
");

                Console.Write("How many products do you want to insert? ");
                int dataRange = int.Parse(Console.ReadLine());
                int count = 0;

                do
                {
                    Console.WriteLine($"\nProduct {count + 1}:\n");

                    Console.Write("Product ID: ");
                    int productID = int.Parse(Console.ReadLine());

                    Console.Write("Product Name: ");
                    string productName = Console.ReadLine();

                    Console.Write("Product Category: ");
                    string productCategory = Console.ReadLine();

                    Console.Write("Product Description: ");
                    string productDescription = Console.ReadLine();

                    Console.Write("Product Price: ");
                    int productPrice = int.Parse(Console.ReadLine());

                    productDB.InsertProduct(productID, productName, productCategory, productDescription, productPrice);
                    Console.Clear();
                    Console.WriteLine("\nProduct inserted successfully!");
                    count++;
                } while (count < dataRange);

                Console.WriteLine("\n\n********************All products inserted successfully!********************");

               
                Console.Write("\nDo you want to insert more products? (Y/N): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    continueInserting = true;
                }
                else
                {
                    continueInserting = false;
                }


            } while (continueInserting);
            Console.Clear();
            Menu.ShowMenu(null);
        }

        class InsertProductDB
        {
            public void InsertProduct(int productID, string productName, string productCategory, string productDescription, int productPrice)
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO products (product_id, product_name, product_category, product_description, product_price) " +
                                        "VALUES (@product_id, @product_name, @product_category, @product_description, @product_price)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@product_id", productID);
                            cmd.Parameters.AddWithValue("@product_name", productName);
                            cmd.Parameters.AddWithValue("@product_category", productCategory);
                            cmd.Parameters.AddWithValue("@product_description", productDescription);
                            cmd.Parameters.AddWithValue("@product_price", productPrice);

                            cmd.ExecuteNonQuery();
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
}