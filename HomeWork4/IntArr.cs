using System;

namespace HomeWork4
{
    class IntArr
    {
        private static int _sizeArr = 15;
        private static int[] _arrInt = { 23, 23, 43, 32, 23, 54, 162, 554 };

        public static int[] ArrInt
        {
            get
            {
                return _arrInt;
            }
            set
            {
                if (SizeArr > 10 && SizeArr < 100)
                {
                    _arrInt = value;
                }
                throw new Exception("Size of array is too small or big");
            }
        }
        public static int SizeArr
        {
            get
            {
                return _sizeArr;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentNullException("Size of array can`t be 0");
                }
                _sizeArr = value;
            }
        }
    }
}
