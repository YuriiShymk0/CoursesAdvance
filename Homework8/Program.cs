using System;
using System.Threading;

namespace Homework8
{
    /*Rework your previously implemented Stack.
     * 1) Make the Push i Pop method thread-safe.
     * 2) Implement the Peek method so that a maximum of 5 threads can read data at a time.
     * 3) In the Main method, create 10 threads that will write data to the stack (Push), 10 threads read data (Pop) and 10 threads for the Peek operation.
     * After each operation, the stream should fall asleep for 50 ms
     */
    class Program
    {
        static Stack<int> stack = new Stack<int>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() =>
                {
                    stack.Push(i);
                    Console.WriteLine($"{Thread.CurrentThread.Name} operation Push number ({i})");
                }
                );
                HelpConsole(thread, i);
            }

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() => Console.WriteLine($"{Thread.CurrentThread.Name}  operation Pop number ({stack.Pop()})"));
                HelpConsole(thread, i);
            }

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() => Console.WriteLine($"{Thread.CurrentThread.Name} operation Peek ({stack.Peek()})"));
                HelpConsole(thread, i);
            }
        }

        public static void HelpConsole(Thread name, int counter)
        {
            name.Name = $"Thread № {counter} :";
            name.Start();
            Thread.Sleep(50);
        }
    }
}
