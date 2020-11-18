using System;
using System.Security.Cryptography;

namespace ExpenseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLoop();
        }

        static void ConsoleLoop()
        {
            Console.WriteLine("Select and option by choosing the corresponding number and pressing enter");
            Console.WriteLine("1. Add an expense");
            Console.WriteLine("2. View spending statistics");
            //Console.WriteLine("3. Generate expense sheet");
            Console.WriteLine("3. Exit program");


            try
            {
                int answer = Int32.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        ExpenseAdder.AddExpenseLoop();
                        break;
                    case 2:
                        ExpenseStats.GetStatsLoop();
                        break;
                    case 3:
                        Console.WriteLine("Closing application...");
                        Environment.Exit(0);
                        break;
                    default:
                        throw new Exception();
                }

                ConsoleLoop();
            }
            catch
            {
                Console.WriteLine("Invalid input - press enter to retry");
                Console.ReadLine();
                Console.Clear();
                ConsoleLoop();
            }
        }
    }
}
