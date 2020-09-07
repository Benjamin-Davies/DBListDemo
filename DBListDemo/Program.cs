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
                Console.Clear();
                Console.WriteLine("Ben's TODO list app");
                Console.WriteLine();

                foreach (var todo in api.GetTodos())
                {
                    Console.WriteLine($"* {todo}");
                }

                Console.WriteLine();
                Console.WriteLine("Press 0 to exit");
                Console.WriteLine("Press 1 to create a new TODO");
                int result = -1;
                int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out result);

                switch (result)
                {
                    case 0:
                        Running = false;
                        break;
                    case 1:
                        throw new NotImplementedException();
                }
            }

        }
    }
}
