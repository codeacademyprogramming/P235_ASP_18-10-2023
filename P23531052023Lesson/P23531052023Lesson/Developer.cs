using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23531052023Lesson
{
    internal class Developer : Student
    {
        public string Language { get; set; }

        public override string ToString()
        {
            return $"{Language}";
        }

        public static implicit operator Enginier(Developer developer)
        {
            Enginier enginier = new Enginier();
            enginier.Name = developer.Name;
            enginier.SurName = developer.SurName;
            enginier.Grade = developer.Grade;
            enginier.Experiance = 99;

            return enginier;
        }
    }
}
