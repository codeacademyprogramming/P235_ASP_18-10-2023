using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23530052023HomeWork1
{
    internal class Engineer : Employee
    {
        private double _salary;
        public override double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                while (value < 1000)
                {
                    Console.WriteLine("Maas 1000 ve 1000-den Cox Olmalidir");
                    string strSalary = Console.ReadLine();
                    double.TryParse(strSalary, out value);
                }

                _salary = value;
            }
        }

        public Engineer(double salary, string fullName)
        {
            FullName = fullName;
            Salary = salary;
        }
    }
}
