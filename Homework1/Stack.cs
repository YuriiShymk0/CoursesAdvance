using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class Stack<T>
    {

        private static T[] _arr = new T[10];
        private static int _counterOFOperation = 0;
        private static T[] _arrForPush = new T[_arr.Length + 1];

        public static void Push(T value)
        {
            if (_counterOFOperation < (0.8 * _arr.Length))
            {
                HelpPush(value);
            }
            else
            {
                Array.Resize<T>(ref _arr,_arr.Length *2);
                HelpPush(value);
            }
        }

        public static void HelpPush(T value)
        {
            _arr.SetValue(value, Array.IndexOf(_arr, 0));
            _arrForPush = (T[])_arr.Clone();
            _counterOFOperation++;
        }
        //public T Pop(T value)
        //{

        //    return ;
        //}

        //public T Peek(T value)
        //{
        //    return;
        //}


    }
}
