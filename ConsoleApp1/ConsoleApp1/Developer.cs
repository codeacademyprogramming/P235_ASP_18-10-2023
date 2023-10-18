using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Developer : Human
    {
        public string Language { get; set; }

        public override void Eat()
        {
            Console.WriteLine();
        }
    }
}
