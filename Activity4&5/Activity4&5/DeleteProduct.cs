using MySql.Data.MySqlClient;
using System;

namespace Activity4_5
{
    class DeleteProduct
    {
        public static void DeleteProductData()
        {
            DeleteProductDB deleteProductDB = new DeleteProductDB();
            bool continueDeleting;

            do
            {
                Console.Clear();
                Console.WriteLine(@"

        ██████╗ ███████╗██╗     ███████╗████████╗███████╗    ██████╗ ██████╗  ██████╗ ██████╗ ██╗   ██╗ ██████╗████████╗
        ██╔══██╗██╔════╝██║     ██╔════╝╚══██╔══╝██╔════╝    ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██║   ██║██╔════╝╚══██╔══╝
        ██║  ██║█████╗  ██║     █████╗     ██║   █████╗      ██████╔╝██████╔╝██║   ██║██║  ██║██║   ██║██║        ██║   
        ██║  ██║██╔══╝  ██║     ██╔══╝     ██║   ██╔══╝      ██╔═══╝ ██╔══██╗██║   ██║██║  ██║██║   ██║██║        ██║   
        ██████╔╝███████╗███████╗███████╗   ██║   ███████╗    ██║     ██║  ██║╚██████╔╝██████╔╝╚██████╔╝╚██████╗   ██║   
        ╚═════╝ ╚══════╝╚══════╝╚══════╝   ╚═╝   ╚══════╝    ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝  ╚═════╝   ╚═╝   
        ");

                Console.Write("Enter the number of products to delete: ");
                int numberOfProducts = int.Parse(Console.ReadLine());

                int count = 0;
                while (count < numberOfProducts)
                {
                    Console.Write("\nEnter Product ID to delete: ");
                    int productID = int.Parse(Console.ReadLine());

                    string deletedProductName = deleteProductDB.DeleteProduct(productID);

                    Console.WriteLine(deletedProductName != null ? $"\n**********Product '{deletedProductName}' has been deleted successfully!**********" : "\n**********Product not found or could not be deleted.**********");
                    count++;
                }

                Console.Write("\nDo you want to delete more products? (Y/N): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    continueDeleting = true;
                }
                else
                {
                    continueDeleting = false;
                }


            } while (continueDeleting);
            Console.Clear();
            Menu.ShowMenu(null);
        }
    }

    class DeleteProductDB
    {
        public string DeleteProduct(int productID)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string selectQuery = "SELECT product_name FROM products WHERE product_id = @product_id";
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@product_id", productID);
                        object result = selectCmd.ExecuteScalar();

                        if (result != null)
                        {
                            string productName = result.ToString();

                            string deleteQuery = "DELETE FROM products WHERE product_id = @product_id";
                            using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@product_id", productID);
                                deleteCmd.ExecuteNonQuery();
                            }

                            return productName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return null;
        }
    }
}
