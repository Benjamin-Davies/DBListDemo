using System;

namespace DBListDemo
{
    static class Program
    {
        private static bool Running = true;
        private static Api api = new Api();

        static void Main(string[] args)
        {
            while (Running)
            {
                Console.WriteLine();
                Console.WriteLine("Ben's TODO list app");
                Console.WriteLine();

                foreach (var todo in api.GetTodos())
                {
                    Console.WriteLine($"* {todo}");
                }

                Console.WriteLine();
                Console.WriteLine("Press 1 to exit");
                Console.WriteLine("Press 2 to create a new TODO");

                // Accept a keypress from the user
                int result = -1;
                int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out result);

                switch (result)
                {
                    case 1: // exit
                        Running = false;
                        break;
                    case 2: // create
                        Console.WriteLine();
                        Console.WriteLine("Please enter a title for your new todo:");
                        string title = Console.ReadLine();

                        Console.WriteLine("Uploading todo...");
                        api.CreateTodo(title);
                        break;
                }
            }

        }
    }
}
