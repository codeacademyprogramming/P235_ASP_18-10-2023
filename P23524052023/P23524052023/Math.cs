using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23524052023
{
    internal class Math
    {
        public int A;
        public int B;

        public Math(int a, int b)
        {
            A = a; 
            B = b;
        }

        public int Sum()
        {
            return A + B;
        }

        public double Devide()
        {
            return (double)A / B;
        }

        public int Multiple()
        {
            return A * B;
        }
    }
}
