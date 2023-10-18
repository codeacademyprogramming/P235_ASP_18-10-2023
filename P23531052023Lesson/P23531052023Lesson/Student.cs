using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23531052023Lesson
{
    internal class Student : Human
    {
        public double Grade { get; set; }

        public sealed override string GetInfo()
        {
            return base.GetInfo();
        }

        //public virtual void Test()
        //{

        //}
    }
}
