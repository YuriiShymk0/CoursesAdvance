using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class User
    {

        private string _name;
        private int _age;
        private IEnumerable _seniority;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name can`t be empty");
                }
                _name = value;
            }
        }
        public IEnumerable Seniority
        {
            get
            {
                return _seniority;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Seniority can`t be smaller than 0");
                }
                _seniority = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 18)
                {
                    throw new ArgumentNullException("Age can`t be smaller than 18");// course person can get seniority after 18
                }
                _age = value;
            }
        }
    }
}
