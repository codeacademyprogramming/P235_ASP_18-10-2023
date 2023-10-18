using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23531052023Lesson
{
    struct Area
    {
        public int A;
        public int B { get; set; }
        public Area(int a,int b)
        {
            A = a;
            B = b;
        }

        public int Calculate()
        {
            return A * B;
        }

        public int Calculate(int c)
        {
            return A * B * c;
        }
    }
}
