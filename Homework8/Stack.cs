using System;
using System.Linq;
using System.Threading;

namespace Homework8
{
    public class Stack<T> where T : struct
    {
        private static T[] _arr = new T[10];
        private static uint countOFOperation = 0;
        public static object locker = new object();
        public static Semaphore semaphore = new Semaphore(5, 5);

        public void Push(T value)
        {
            lock (locker)
            {
                if (countOFOperation > (0.8 * (_arr.Length + 1)))
                {
                    Array.Resize<T>(ref _arr, _arr.Length * 2);
                }
                _arr.SetValue(value, Array.IndexOf(_arr, _arr[countOFOperation]));
                countOFOperation++;
            }
        }

        public T Pop()
        {
            lock (locker)
            {
                if (countOFOperation > 1)
                {
                    _arr = _arr.Where((source, index) => index != countOFOperation - 1).ToArray();
                    countOFOperation--;
                    return _arr[countOFOperation - 1];
                }
                return default;
            }
        }

        public T Peek()
        {
            semaphore.WaitOne();
            Thread.Sleep(2000);
            semaphore.Release();
            return _arr[0];
        }

    }

}
