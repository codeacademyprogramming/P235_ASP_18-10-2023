using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23526052023Interface
{
    internal class Car : ITEst
    {
        public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Walk(string a)
        {
            Console.WriteLine(a);
        }

        public void Test()
        {

        }
    }
}
