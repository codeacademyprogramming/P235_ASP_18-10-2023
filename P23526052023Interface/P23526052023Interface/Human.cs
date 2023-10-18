using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23526052023Interface
{
    internal class Human : MyClass, ITEst, Interface1,Interface2
    {
        public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Walk(string b)
        {
            Console.WriteLine(b);
        }
    }
}
