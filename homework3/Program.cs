using System;
using System.Collections.Generic;

namespace homework3
{
    class Program
    {
        public static int firstValue, secondValue,result;
        public static char operation;
        delegate int Calculation(int firstValue, int secondValue);

        static void Main(string[] args)
        {
            firstValue = EnterNumbersFromConsole();
            secondValue = EnterNumbersFromConsole();
            operation = EnterCharFromConsole();

            Calculation Sum = delegate (int firstValue, int secondValue)
            {
                return firstValue + secondValue;
            };
            Calculation Subtraction = delegate (int firstValue, int secondValue)
            {
                return firstValue - secondValue;
            };
            Calculation Multiplication = delegate (int firstValue, int secondValue)
            {
                return firstValue * secondValue;
            };
            Calculation Division = delegate (int firstValue, int secondValue)
            {
                if (secondValue != 0)
                {
                    return firstValue / secondValue;
                }
                return 0;
            };

            switch (operation)
            {
                case '+':
                    {
                        Console.WriteLine(TextOnConsole() + Sum(firstValue, secondValue));
                        break;
                    }
                case '-':
                    {
                        Console.WriteLine(TextOnConsole() + Subtraction(firstValue, secondValue));
                        break;
                    }
                case '*':
                    {
                        Console.WriteLine(TextOnConsole() + Multiplication(firstValue, secondValue));
                        break;
                    }
                case '/':
                    {
                        Console.WriteLine(TextOnConsole() + Division(firstValue, secondValue));
                        break;
                    }
            }
            
        }
        public static int EnterNumbersFromConsole()
        {
            while (true)
            {
                Console.WriteLine("Please enter  number : ");
                if (int.TryParse(Console.ReadLine(), out int valueFromConsole))
                {
                    return valueFromConsole;
                }
                else
                {
                    Console.WriteLine("Try again ");
                }
            }
        }

        public static char EnterCharFromConsole()
        {
            while (true)
            {
                Console.WriteLine($"Please choose  type of operation for {firstValue} and {secondValue} ");
                Console.WriteLine("1.Sum\n2.Subtraction\n3.Multiplication\n4.Division");
                if (int.TryParse(Console.ReadLine(), out int valueFromConsole))
                {
                    switch (valueFromConsole)
                    {
                        case 1:
                            {
                                return '+';
                            }
                        case 2:
                            {
                                return '-';
                            }
                        case 3:
                            {
                                return '/';
                            }
                        case 4:
                            {
                                return '*';
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("Try again ");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Try again ");
                }
            }
        }
        public static string TextOnConsole() => "Result of Operation: ";
       
    }

}
