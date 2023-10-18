using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23526052023Polymorphsym
{
    internal class Developer : Student
    {
        public string Language { get; set; }

        public override /*void*/ string GetFullInfo()
        {
            return $"{base.GetFullInfo()} {Language}";
        }
    }
}
