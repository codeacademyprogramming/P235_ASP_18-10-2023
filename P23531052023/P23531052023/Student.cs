using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23531052023
{
    internal class Student
    {
        public string Name;
        public string SurName;

        public override string ToString()
        {
            return $"Name: {Name}\nSurName: {SurName}";
        }
    }
}
