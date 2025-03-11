using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity4_5
{
    class Menu
    {
        public static void ShowMenu(object userName)
        {
            Console.WriteLine(@"

             __ __ __       ______       __           ______       ______       ___ __ __      ______      
            /_//_//_/\     /_____/\     /_/\         /_____/\     /_____/\     /__//_//_/\    /_____/\     
            \:\\:\\:\ \    \::::_\/_    \:\ \        \:::__\/     \:::_ \ \    \::\| \| \ \   \::::_\/_    
             \:\\:\\:\ \    \:\/___/\    \:\ \        \:\ \  __    \:\ \ \ \    \:.      \ \   \:\/___/\   
              \:\\:\\:\ \    \::___\/_    \:\ \____    \:\ \/_/\    \:\ \ \ \    \:.\-/\  \ \   \::___\/_  
               \:\\:\\:\ \    \:\____/\    \:\/___/\    \:\_\ \ \    \:\_\ \ \    \. \  \  \ \   \:\____/\ 
                \_______\/     \_____\/     \_____\/     \_____\/     \_____\/     \__\/ \__\/    \_____\/ 
                                                                                               
                            
        ");
            Console.WriteLine("[1] Insert Products");
            Console.WriteLine("[2] View Products");
            Console.WriteLine("[3] Update Products");
            Console.WriteLine("[4] Delete Products");
            Console.WriteLine("[5] Log Out");
            Console.Write("Choose a Number:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    InsertProduct.InsertProductData();
                    break;
                case 2:
                    Console.Clear();
                    ViewProduct.ViewProductData();
                    break;
                case 3:
                    UpdateProduct.UpdateProductData();
                    break;
                case 4:
                    Console.Clear();
                    DeleteProduct.DeleteProductData();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine($"You are Logged Out, {userName}.");
                    Start.FirstPage();
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please Try Again.");
                    break;
            }
        }
    }
}
