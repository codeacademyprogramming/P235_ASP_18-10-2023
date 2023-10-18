using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235OperatorOverloading
{
    internal class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public double Age { get; set; }

        public static double operator +(Student stu1,Student stu2)
        {
            return stu1.Age + stu2.Age;
        }

        public static double operator /(Student stu1, Student stu2)
        {
            return stu1.Age / stu2.Age;
        }

        public static bool operator>(Student stu1, Student stu2)
        {
            return true;
        }

        public static bool operator <(Student stu1, Student stu2)
        {
            return true;
        }

        public static bool operator ==(Student stu1, Student stu2)
        {
            return true;
        }

        public static bool operator !=(Student stu1, Student stu2)
        {
            return true;
        }
    }
}
