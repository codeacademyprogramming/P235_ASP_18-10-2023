using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Abstract Keywordune Sahib Olan Class-lardan Instance(object) Yaratmaq Olmur
    //Abstract Method Yalniz Abstract Class Yarada Bilirik
    internal abstract class Human
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public byte Age { get; set; }

        public abstract void Eat();

        public virtual void Test(string name)
        {

        }
        
    }
}
