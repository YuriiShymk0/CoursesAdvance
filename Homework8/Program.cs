using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Homework8
{
    class Program
    {
        static Stack<int> stack = new Stack<int>();
        static Semaphore semaphore = new Semaphore(5, 5);

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() => stack.Push(i));
                thread.Start();
                Thread.Sleep(50);
            }
            for (int i = 0; i < 10; i++)
            {
                Thread thread1 = new Thread(() => Console.WriteLine(stack.Pop())); ;
                thread1.Start();
                Thread.Sleep(50);
            }
            for (int i = 0; i < 10; i++)
            {
                Thread thread2 = new Thread(() => Console.WriteLine(stack.Peek()));
                thread2.Start();
                Thread.Sleep(50);
            }

        }
       
    }
}
