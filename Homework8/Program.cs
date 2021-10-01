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
                Thread thread = new Thread(new ParameterizedThreadStart(HelpPush()));
                thread.Start(i);
                Thread.Sleep(50);
            }
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(stack.Pop);
                thread.Start(i);
                Thread.Sleep(50);
            }
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(stack.Peek);
                thread.Start(i);
                Thread.Sleep(50);
            }
            
        }
        public static void HelpPush(int i)
        {
            stack.Push(i);
        }
    }
}
