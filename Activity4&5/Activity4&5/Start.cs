
using System;

namespace Activity4_5
{
    class Start
    {
        public static void FirstPage()
        {
            while (true)
            {
                Console.WriteLine(@"
                ____                    __              __     __  ___                                       
               / __ \ _____ ____   ____/ /__  __ _____ / /_   /  |/  /____ _ ____   ____ _ ____ _ ___   _____
              / /_/ // ___// __ \ / __  // / / // ___// __/  / /|_/ // __ `// __ \ / __ `// __ `// _ \ / ___/
             / ____// /   / /_/ // /_/ // /_/ // /__ / /_   / /  / // /_/ // / / // /_/ // /_/ //  __// /    
            /_/    /_/    \____/ \__,_/ \__,_/ \___/ \__/  /_/  /_/ \__,_//_/ /_/ \__,_/ \__, / \___//_/     
                                                                                      \______/                                                                                                                                                               
                ");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Register");
                Console.WriteLine("[3] Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Login.LoginUser();
                        return;
                    case 2:
                        Console.Clear();
                        Register.RegisterUser();
                        return;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Exiting... Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }
            }
        }
    }
}
