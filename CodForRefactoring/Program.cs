using System;
using System.Collections.Generic;

namespace CodForRefactoring
{
    class Program
    {
        static void Main()
        {
            ConsoleTitle();
            ChooseAComand();
        }

        public static void ChooseAComand()
        {
            KeyEvent evnt = new KeyEvent();
            evnt.KeyDown += (sender, e) =>
            {
                switch (e.ch)
                {
                    case 'C':
                        {
                            ChooseColor(true);
                            break;
                        }
                    case 'B':
                        {
                            ChooseColor(false);
                            break;
                        }
                    case 'S':
                        {
                            Console.Write("\nSet hight: ");
                            try
                            {
                                Console.WindowHeight = int.Parse(Console.ReadLine()) / 8;
                                Console.Write("Set width: ");
                                Console.WindowWidth = int.Parse(Console.ReadLine()) / 8;
                                Console.WriteLine();
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Unknown format!");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("To large param!");
                            }
                            break;
                        }
                    case 'T':
                        {
                            Console.Write("\nWrite a title: ");
                            Console.Title = Console.ReadLine();
                            Console.WriteLine();
                            break;
                        }
                    case 'R':
                        {
                            Console.ForegroundColor = System.ConsoleColor.White;
                            Console.BackgroundColor = System.ConsoleColor.Black;
                            Console.WriteLine();
                            break;
                        }
                    case 'E':
                        {
                            Console.Beep();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nCommand not found!");
                            break;
                        }
                }
            };
            evnt.KeyDown += Separation;
            char chaForKeyDown;
            do
            {
                Console.Write("Write a command: ");
                ConsoleKeyInfo key = Console.ReadKey();
                chaForKeyDown = key.KeyChar;
                evnt.OnKeyDown(key.KeyChar);
            }
            while (chaForKeyDown != 'E');
        }
       
        static void ConsoleTitle()
        {
            ConsoleColor(System.ConsoleColor.Green);
            Console.WriteLine("***************************\n\nConsole tune program" + "\n___________________________\n");
            ConsoleColor(System.ConsoleColor.Yellow);
            Console.WriteLine("Commands: \n");
            foreach (var comand in comands)
            {
                Command(comand.Key, comand.Value);
            }
            Console.WriteLine();
        }

        static void ConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        static void Command(string s1, string s2)
        {
            ConsoleColor(System.ConsoleColor.Red);
            Console.Write(s1);
            ConsoleColor(System.ConsoleColor.White);
            Console.Write(" - " + s2 + "\n");
        }

        /// <summary>
        /// Changes ForegroundColor or BackgroundColor
        /// </summary>
        /// <param name="ForegroundColor">if ForegroundColor = false - changes BackgroundColor</param>
        static void ChooseColor(bool ForegroundColor = true, string color = "")
        {
            while (true)
            {
                if (color == "")
                {
                    Console.Write("\nWrite a color: ");
                    color = Console.ReadLine();
                }
                if (consoleColors.ContainsKey(color))
                {
                    if (ForegroundColor)
                    {
                        Console.ForegroundColor = consoleColors[color];
                    }
                    else
                    {
                        Console.BackgroundColor = consoleColors[color];
                    }
                    break;
                }
                else
                {
                    color = "empty";
                    Console.WriteLine("Try smth another :(");
                }
            }
            Console.WriteLine("Color Changed!");
        }

        private static Dictionary<string, ConsoleColor> consoleColors = new Dictionary<string, ConsoleColor>
        {
              { "Black", System.ConsoleColor.Black },
              { "Yellow", System.ConsoleColor.Yellow },
              { "Green", System.ConsoleColor.Green },
              { "Red", System.ConsoleColor.Red },
              { "Blue", System.ConsoleColor.Blue },
              { "Gray", System.ConsoleColor.Gray },
              { "White", System.ConsoleColor.White },
        };

        private static Dictionary<string, string> comands = new Dictionary<string, string>
        {
            { "C", "Change font color" },
            { "B", "Change background dolor" },
            { "S", "Change console size"},
            {"T", "Change window header" },
            { "R", "Reset changes"},
            { "E", "Exit"}
        };
        public static void Separation(object sender, MyEventArgs arg)
        {
            Console.WriteLine("__________________________________");
        }
    }
}