using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23526052023Polymorphsym
{
    internal class Student : Human
    {
        private byte _age;
        public override byte Age 
        {
            get 
            {
                return _age;
            }
            set 
            {
                if(value > 15)
                {
                    _age = value;
                }
            } 
        }
        public double Grade { get; set; }

        public override /*void*/ string GetFullInfo()
        {
            //Console.WriteLine($"{Name} {SurName} {Grade}");
            return $"{base.GetFullInfo()} {Grade}";
        }
    }
}
