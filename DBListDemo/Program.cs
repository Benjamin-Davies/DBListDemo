using System;
using System.Threading.Tasks;

namespace DBListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var task = Task.Run(program.Run);
            task.Wait();
        }

        private static bool Running = true;

        async Task Run()
        {
            while (Running)
            {
                Console.Clear();
                Console.WriteLine("Ben's TODO list app");
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
