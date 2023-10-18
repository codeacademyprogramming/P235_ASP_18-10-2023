using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23530052023HomeWork1
{
    internal class Employee
    {
        public string FullName;
        private double _salary;
        public virtual double Salary 
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value >= 300) 
                {
                    _salary = value;
                }
                else
                {
                    Console.WriteLine("Maas 300-den az ola bilmez");
                }


            }
        }
    }
}
