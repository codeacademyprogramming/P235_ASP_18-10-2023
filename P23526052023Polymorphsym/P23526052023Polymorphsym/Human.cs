using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23526052023Polymorphsym
{
    internal class Human
    {
        private byte _age;
        public virtual byte Age 
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 10)
                {
                    _age = value;
                }
            }
        }

        public string Name { get; set; }
        public string SurName { get; set; }

        public virtual /*void*/ string GetFullInfo()
        {
            //Console.WriteLine($"{Name} {SurName}");
            return $"{Name} {SurName}";
        }

        protected virtual string GetFullName()
        {
            return $"{Name} {SurName}";
        }
    }
}
