using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine(stack.Pop());
            };
            Console.WriteLine(stack.Peek());
            for (int i = 0; i < 14; i++)
            {
                stack.Push(i);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
