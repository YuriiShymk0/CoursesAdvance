
using System;
using System.Linq;

namespace Homework2
{
    public class Stack<T> where T : struct
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
            if (countOFOperation > 1)
            {
                _arr = _arr.Where((source, index) => index != countOFOperation - 1).ToArray();
                countOFOperation--;
                return _arr[countOFOperation - 1];
            }
            return default;
        }

        public T Peek()
        {
            return _arr[0];
        }
    }
}
