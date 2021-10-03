using System;
using System.Runtime.Serialization;

namespace Library
{
    public class User
    {
        private string _name;
        private string _surname;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentNullException("Name can`t be empty");
                }
            }
        }

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
                    throw new ArgumentNullException("Surname can`t be empty");
                }
            }
        }
    }
 
    [Serializable]
    public class Company
    {
        private string _company_name;

        public string CompanyName
        {
            get
            {
                return _company_name;
            }
            set
            {
                if (value != null)
                {
                    _company_name = value;
                }
                else
                {
                    throw new ArgumentNullException("CompanyName can`t be empty");
                }
            }
        }
    }
}
