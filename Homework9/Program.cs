using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading;


namespace Homework9
{
    class Program 
    {
        static void Main(string[] args)
        {
             MeinMenu();
       
        }

        private static void MeinMenu()
        {
            while (true)
            {
                Console.WriteLine("Please choose .dll to connection:\n\n1.Press 1 to connect Library1.dll(with serializable User)\n2.Press 2 to connect Library2.dll(with serializable Company)");
                if (int.TryParse(Console.ReadLine(), out int valueFromConsole))
                {
                    switch (valueFromConsole)
                    {
                        case 1:
                            ObjectHandle handle = Activator.CreateInstance("Library1", "Library.User");
                            object p = handle.Unwrap();
                            Type t = p.GetType();
                            PropertyInfo nameprop = t.GetProperty("Name");
                            if (nameprop != null)
                                nameprop.SetValue(p, "Sam");
                            PropertyInfo surnameprop = t.GetProperty("Surname");
                            if (surnameprop != null)
                                surnameprop.SetValue(p, "Jeckson");
                            if (t.IsSerializable)
                            {
                                Console.WriteLine(handle.ToString());
                            }
                            break;
                        case 2:
                            ObjectHandle handle1 = Activator.CreateInstance("Library2", "Library.Company");
                            object p1 = handle1.Unwrap();
                            Type t1 = p1.GetType();
                            PropertyInfo prop1 = t1.GetProperty("CompanyName");
                            if (prop1 != null)
                                prop1.SetValue(p1, "Nike");
                            if (t1.IsSerializable)
                            {
                                Console.WriteLine(p1.ToString());
                            }
                            break;
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
