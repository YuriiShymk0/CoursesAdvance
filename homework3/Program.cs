using System;

namespace homework3
{
    class Program
    {
        public static int firstValue, secondValue, result;
        public static char operation;
        delegate int Calculation(int firstValue, int secondValue);

        static void Main(string[] args)
        {
            firstValue = EnterNumbersFromConsole();
            secondValue = EnterNumbersFromConsole();
            operation = EnterCharFromConsole();

            CalculationWithanonimDelegate();//anonim methods

            CalculationWithFuncDelegate();//Func methods

            HelloWithAction();//my way of solving the problem

            HelloWithActionAndLIamda();//i think it should work that way

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
                            return '+';
                        case 2:
                            return '-';
                        case 3:
                            return '*';
                        case 4:
                            return '/';
                        default:
                            Console.Clear();
                            Console.WriteLine("Try again ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Try again ");
                }
            }
        }

        public static string TextOnConsole(int forChoose)
        {
            if (forChoose == 1)
            {
                return "Result of Operation with using anonim methods: ";
            }
            return "Result of Operation with using \"Func\" Delegate: ";
        }

        public static void CalculationWithanonimDelegate()
        {
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
                Error();
                return 0;
            };

            switch (operation)
            {
                case '+':
                    Console.WriteLine(TextOnConsole(1) + Sum(firstValue, secondValue));
                    break;
                case '-':
                    Console.WriteLine(TextOnConsole(1) + Subtraction(firstValue, secondValue));
                    break;
                case '*':
                    Console.WriteLine(TextOnConsole(1) + Multiplication(firstValue, secondValue));
                    break;
                case '/':
                    Console.WriteLine(TextOnConsole(1) + Division(firstValue, secondValue));
                    break;
            }
        }

        public static int Sum(int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        public static int Subtraction(int firstValue, int secondValue)
        {
            return firstValue - secondValue;
        }

        public static int Multiplication(int firstValue, int secondValue)
        {
            return firstValue * secondValue;
        }

        public static int Division(int firstValue, int secondValue)
        {
            if (secondValue != 0)
            {
                return firstValue / secondValue;
            }
            Error();
            return 0;
        }

        public static void CalculationWithFuncDelegate()
        {
            Func<int, int, int> sum = Sum;
            Func<int, int, int> subtraction = Subtraction;
            Func<int, int, int> multiplication = Multiplication;
            Func<int, int, int> division = Division;
            switch (operation)
            {
                case '+':
                    Console.WriteLine(TextOnConsole(0) + sum(firstValue, secondValue));
                    break;
                case '-':
                    Console.WriteLine(TextOnConsole(0) + subtraction(firstValue, secondValue));
                    break;
                case '*':
                    Console.WriteLine(TextOnConsole(0) + multiplication(firstValue, secondValue));
                    break;
                case '/':
                    Console.WriteLine(TextOnConsole(0) + division(firstValue, secondValue));
                    break;
            }
        }

        public static void Error()
        {
            Console.WriteLine("cannot be divided by zero");
        }

        public static void HelloWithAction()
        {
            Action<string,string> HelloOnConsole;
            HelloOnConsole = (s,d) => Console.WriteLine($"{s}\n{d}");
            HelloOnConsole ("Hello World" ,"Good bye");
        }

        public static void HelloWithActionAndLIamda()
        {
            Action action = () => HelloWorld();
            action += () => GoodBye();
            action();
        }
        


        public static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }

        public static void GoodBye()
        {
            Console.WriteLine("Good bye");
        }
    }
}
