using System;

namespace HomeWork4
{
    class Abiturient
    {
        private string _surname;
        private int _schoolNumber;
        private int _yearOfEntry;

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value != null)
                {
                    _surname = value;
                }
                else
                {
                    throw new ArgumentNullException("Surname is empty");
                }
            }
        }

        public int SchoolNumber
        {
            get
            {
                return _schoolNumber;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentNullException("SchoolNumber can`t be 0");
                }
                _schoolNumber = value;
            }
        }

        public int YearOfEntry
        {
            get
            {
                return _yearOfEntry;
            }
            set
            {
                if (_yearOfEntry > DateTime.Now.Year)
                {
                    throw new ArgumentException(string.Format("imposible year of {0}", nameof(_yearOfEntry)));
                }
                _yearOfEntry = value;
            }
        }
    }

}
