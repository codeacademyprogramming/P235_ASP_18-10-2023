using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23531052023Lesson
{
    internal class Test
    {
        public int Year { get; set; }
        public static explicit operator Academy(Test test1)
        {
            return new Academy();
        }
    }
}
