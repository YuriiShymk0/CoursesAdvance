using System;

namespace Homework1
{
    class Program
    {
        /*Implement your own Stack data structure.
         * Your class should include Push, Pop, and Peek methods. As a basis it is possible to take an array, that is that in the middle of a stack elements were stored in an array.
         * For simplicity, implement it to work with only one type of data (such as int).
         * When filling the internal array by 80%, it must dynamically expand (double) and copy into the newly created array all the elements from the previous one.
         */
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
