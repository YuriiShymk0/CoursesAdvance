using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            
            for (int i = 0; i < 55; i++)
            {
                stack.Push(i);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
