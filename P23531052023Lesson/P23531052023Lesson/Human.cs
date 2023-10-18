using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23531052023Lesson
{
    internal class Human : ITest
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public virtual string GetInfo()
        {
            return Name;
        }
    }
}
