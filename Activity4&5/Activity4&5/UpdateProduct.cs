using MySql.Data.MySqlClient;
using System;

namespace Activity4_5
{
    class UpdateProduct
    {
        public static void UpdateProductData()
        {
            UpdateProductDB productDB = new UpdateProductDB();
            string column = null;
            string newValue = null;
            bool continueUpdating = true;
            int productID;

            Console.Clear();
            Console.WriteLine(@"

         __ __  ____   ___     ____  ______    ___      ____   ____    ___   ___    __ __     __  ______ 
        |  T  T|    \ |   \   /    T|      T  /  _]    |    \ |    \  /   \ |   \  |  T  T   /  ]|      T
        |  |  ||  o  )|    \ Y  o  ||      | /  [_     |  o  )|  D  )Y     Y|    \ |  |  |  /  / |      |
        |  |  ||   _/ |  D  Y|     |l_j  l_jY    _]    |   _/ |    / |  O  ||  D  Y|  |  | /  /  l_j  l_j
        |  :  ||  |   |     ||  _  |  |  |  |   [_     |  |   |    \ |     ||     ||  :  |/   \_   |  |  
        l     ||  |   |     ||  |  |  |  |  |     T    |  |   |  .  Yl     !|     |l     |\     |  |  |  
         \__,_jl__j   l_____jl__j__j  l__j  l_____j    l__j   l__j\_j \___/ l_____j \__,_j \____j  l__j  
                                                                                                 
");

            while (true)
            {
                Console.Write("Enter the Product ID to update: ");
                productID = int.Parse(Console.ReadLine());

                if (productDB.ProductExists(productID))
                {
                    productDB.DisplayCurrentProductDetails(productID);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nProduct not found! Please enter a valid Product ID.\n");
                }
            }

            while (continueUpdating)
            {
                Console.WriteLine("\nSelect the information to update:");
                Console.WriteLine("1. Product Name");
                Console.WriteLine("2. Category");
                Console.WriteLine("3. Description");
                Console.WriteLine("4. Price");
                Console.WriteLine("5. Back to Menu  ");
                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        column = "product_name";
                        Console.Write("Enter new product name: ");
                        newValue = Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        column = "product_category";
                        Console.Write("Enter new category: ");
                        newValue = Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        column = "product_description";
                        Console.Write("Enter new description: ");
                        newValue = Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        column = "product_price";
                        Console.Write("Enter new price: ");
                        newValue = Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Menu.ShowMenu(null);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        continue;
                }

                productDB.UpdateProduct(productID, column, newValue);

                Console.Write("\nDo you want to modify anything else for this product? (Y/N): ");
                string modifyMore = Console.ReadLine().ToLower();
                if (modifyMore == "y")
                {
                    continueUpdating = true;
                }
                else
                {
                    continueUpdating = false;
                }
            }

            Console.Clear();
            Menu.ShowMenu(null);
        }
    }

    class UpdateProductDB
    {
        public bool ProductExists(int productID)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM products WHERE product_id = @product_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@product_id", productID);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void DisplayCurrentProductDetails(int productID)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT product_name, product_category, product_description, product_price FROM products WHERE product_id = @product_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@product_id", productID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("\n===== CURRENT PRODUCT DETAILS =====");
                            Console.WriteLine($"Product Name    : {reader["product_name"]}");
                            Console.WriteLine($"Category        : {reader["product_category"]}");
                            Console.WriteLine($"Description     : {reader["product_description"]}");
                            Console.WriteLine($"Price           : {reader["product_price"]}");
                            Console.WriteLine("===================================");
                        }
                    }
                }
            }
        }

        public void UpdateProduct(int productID, string column, string newValue)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = $"UPDATE products SET {column} = @new_value WHERE product_id = @product_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@new_value", newValue);
                    cmd.Parameters.AddWithValue("@product_id", productID);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\n-------------------------------------------------------------");
                        Console.WriteLine($"*************{column.Replace("_", " ").ToUpper()} UPDATED SUCCESSFULLY!*************");
                        Console.WriteLine("---------------------------------------------------------------\n");

                        DisplayUpdatedProductDetails(productID);
                    }
                    else
                    {
                        Console.WriteLine("\nFailed to update product.");
                    }
                }
            }
        }

        private static void DisplayUpdatedProductDetails(int productID)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT product_name, product_category, product_description, product_price FROM products WHERE product_id = @product_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@product_id", productID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("\n===== UPDATED PRODUCT DETAILS =====");
                            Console.WriteLine($"Product Name    : {reader["product_name"]}");
                            Console.WriteLine($"Category        : {reader["product_category"]}");
                            Console.WriteLine($"Description     : {reader["product_description"]}");
                            Console.WriteLine($"Price           : {reader["product_price"]}");
                            Console.WriteLine("===================================");
                        }
                    }
                }
            }
        }
    }
}