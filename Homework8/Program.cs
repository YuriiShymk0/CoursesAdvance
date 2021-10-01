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
                thread.Name = $"Thread № {i} ";
                thread.Start();
                Thread.Sleep(50);
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Thread thread1 = new Thread(() => Console.WriteLine($"{Thread.CurrentThread.Name}  operation Pop number ({stack.Pop()})"));
                thread1.Name = $"Thread № {i} :";
                thread1.Start();
                Thread.Sleep(50);
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Thread thread2 = new Thread(() => Console.WriteLine($"{Thread.CurrentThread.Name} operation Peek ({stack.Peek()})"));
                thread2.Name = $"Thread № {i} :";
                thread2.Start();
                Thread.Sleep(50);
            }
        }
    }
}
