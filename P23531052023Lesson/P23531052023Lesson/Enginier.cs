using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23531052023Lesson
{
    internal class Enginier : Student
    {
        public int Experiance { get; set; }

        public static explicit operator Developer(Enginier enginier1)
        {
            return new Developer 
            { 
                Name = enginier1.Name, 
                SurName = enginier1.SurName, 
                Grade = enginier1.Grade, 
                Language = "Explicit" };
        }
    }
}
