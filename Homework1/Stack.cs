
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
        private uint countOFOperation = 0;

        public void Push(T value)
        {
            if (countOFOperation > (0.8 * (_arr.Length + 1)))
            {
                Array.Resize<T>(ref _arr, _arr.Length * 2);
            }
            _arr.SetValue(value, Array.IndexOf(_arr, _arr[countOFOperation]));
            countOFOperation++;
        }


        public T Pop()
        {
            if (countOFOperation > 0)
            {
                _arr = _arr.Skip(1).ToArray();
                countOFOperation--;
                return Peek();
            }
            else if (default(T) == null)
            {
                return (T)(object)"0";  //костиль для виведення нуля
            }
            return default;
        }

        public T Peek()
        {
            return _arr[0];
        }


    }
}
