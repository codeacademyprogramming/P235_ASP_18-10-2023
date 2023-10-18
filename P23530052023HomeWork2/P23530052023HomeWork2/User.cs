using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23530052023HomeWork2
{
    internal class User
    {
        private string _userName;
        public string UserName 
        {
            get
            {
                return _userName;
            }
            set
            {
                while (value.Length < 8)
                {
                    Console.WriteLine("User Name Deyer Minimum 8 Simvol Olmalidir");
                    value = Console.ReadLine();
                }

                _userName = value;
            }
        }
        public User(string userName)
        {
            UserName = userName;
        }

        private string _password;
        public string Password 
        {
            get
            {
                return _password;
            }
            set
            {
                _password = CheckPassword(value);
            }
        }

        private string CheckPassword(string password)
        {
        step1:
            while (password.Length < 8)
            {
                Console.WriteLine("PassWord Minimum 8 simvol Olmalidir");
                password = Console.ReadLine();
            }

            bool checkLower = false;
            bool checkUpper = false;
            bool checkNumber = false;

            foreach (char item in password)
            {
                if (char.IsLower(item))
                {
                    checkLower = true;
                }
                else if (char.IsUpper(item))
                {
                    checkUpper = true;
                }
                else if (char.IsDigit(item))
                {
                    checkNumber = true;
                }
            }

            if (checkLower == true && checkUpper == true && checkNumber == true)
            {
                _password = password;
            }
            else
            {
                Console.WriteLine("Duzgun Sifre Daxil Et");
                password = Console.ReadLine();
                goto step1;
            }

            return password;
        }
    }
}
