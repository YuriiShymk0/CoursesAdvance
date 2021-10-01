using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Homework8
{
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
                Thread thread1 = new Thread(() => Console.WriteLine($"{Thread.CurrentThread.Name}  operation Pop number ({stack.Pop()})"));
                HelpConsole(thread1, i);
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Thread thread2 = new Thread(() => Console.WriteLine($"{Thread.CurrentThread.Name} operation Peek ({stack.Peek()})"));
                HelpConsole(thread2,i);
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
