using System;

namespace DBListDemo
{
    static class Program
    {
        private static bool Running = true;
        private static readonly Api api = new Api();

        static void Main()
        {
            while (Running)
            {
                Console.WriteLine();
                Console.WriteLine("Ben's TODO list app");
                Console.WriteLine();

                var todos = api.GetTodos();
                for (int i = 0; i < todos.Length; i++)
                {
                    var todo = todos[i];
                    Console.WriteLine($"{i + 1}. {todo}");
                }

                Console.WriteLine();
                Console.WriteLine("Press q to quit");
                Console.WriteLine("Press c to create a new TODO");

                // Accept a keypress from the user
                char key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case 'q': // exit
                        Running = false;
                        break;
                    case 'c': // create
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
