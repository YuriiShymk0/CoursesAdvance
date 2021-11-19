using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading;


namespace Homework9
{
    /*
     * Create two separate projects Library1.dll and Library2.dll (to have two separate dll files).
     * In the middle of these projects should be defined by the class User i Company. Namespaces in these libraries should be named the same.
     * In project 1 of the User class add the Serializeble attribute and in project 2 Serializeble add to the Company class.
     * Create a console program that will ask which library the user wants to download, 1 or 2.
     * Load the required dll and create an object of that class from this dll, which will be marked with the Serializeble attribute.
     */
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
