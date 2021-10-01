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
                Thread thread = new Thread(HelpPush);
                thread.Start(i);
            }
        }
        public static void HelpPush()
        {
            stack.Push(5);
        }
    }
}
