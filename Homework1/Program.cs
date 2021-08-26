using System;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack<int> stack = new Stack<int>();
            // for (int i = 0; i < 14; i++)
            //{
            //    stack.Pop();
            //};
            //Console.WriteLine(stack.Peek());
            //for (int i = 0; i < 14; i++)
            //{
            //    stack.Push(i);
            //}
            //Console.WriteLine(stack.Peek());

            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 14; i++)
            {
                stack.Pop();
            }
            Console.WriteLine(stack.Peek());
            for (int i = 0; i < 14; i++)
            {
                stack.Push("d");
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
