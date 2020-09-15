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
                Console.WriteLine("Press d to delete a TODO");

                // Accept a keypress from the user
                char key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case 'q': // exit
                        Running = false;
                        break;
                    case 'c': // create
                        Console.WriteLine();
                        Console.WriteLine("Please enter a title for your new todo (empty cancels):");
                        string title = Console.ReadLine();

                        if (title.Length > 0)
                        {
                            Console.WriteLine("Uploading todo...");
                            api.CreateTodo(title);
                        }
                        break;
                    case 'd': // delete
                        Console.WriteLine();
                        Console.WriteLine("Please type the number of the todo that you want to delete (empty cancels):");
                        string number = Console.ReadLine();

                        if (number.Length > 0)
                        {
                            if (int.TryParse(number, out int n) && n > 0 && n <= todos.Length)
                            {
                                Console.WriteLine($"Deleting todo {number}...");
                                api.DeleteTodo(n);
                            }
                            else
                            {
                                Console.WriteLine($"There is no todo matching {number}");
                            }
                        }
                        break;
                }
            }
        }
    }
}
