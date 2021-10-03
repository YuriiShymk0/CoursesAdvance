using System;
using System.Reflection;
using System.Threading;


namespace Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MeinMenu();
            Console.WriteLine(result);
        }

        private static object MeinMenu()
        {
            while (true)
            {
                Console.WriteLine("Please choose .dll to connection:\n\n1.Press 1 to connect Library1.dll(with serializable User)\n2.Press 2 to connect Library2.dll(with serializable Company)");
                if (int.TryParse(Console.ReadLine(), out int valueFromConsole))
                {
                    switch (valueFromConsole)
                    {
                        case 1:
                            Assembly assembly = Assembly.LoadFrom("Library1.dll");
                            Type type = assembly.GetType("Library.User", true, true);
                            object obj = Activator.CreateInstance(type);
                            return obj;
                        case 2:
                            Assembly assembly1 = Assembly.LoadFrom("Library2.dll");
                            Type type1 = assembly1.GetType("Library.Company", true, true);
                            object obj1 = Activator.CreateInstance(type1);
                            return obj1;
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
