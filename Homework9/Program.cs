using System;
using System.Threading;
using Library;

namespace Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MeinMenu());
        }
        private static int MeinMenu()
        {
            while (true)
            {
                Console.WriteLine("Please choose .dll to connection:\n\n1.Press 1 to connect Library1.dll(with serializable User)\n2.Press 2 to connect Library2.dll(with serializable Company)");
                if (int.TryParse(Console.ReadLine(), out int valueFromConsole ))
                {
                    switch (valueFromConsole)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        default:
                            Console.WriteLine("\t\t\t\t\t\tTry again ");
                            Thread.Sleep(700);
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\t\tTry again ");
                    Thread.Sleep(700);
                    Console.Clear();
                }
            }
        }
    }
}
