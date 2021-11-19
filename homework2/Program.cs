using System;

namespace Homework2
{
    class Program
    /*1. Make the stack implemented in the first lesson generalized and so that it can work only with structures*/
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
