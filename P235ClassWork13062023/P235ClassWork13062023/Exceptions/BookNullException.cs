using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235ClassWork13062023.Exceptions
{
    internal class BookNullException : NullReferenceException
    {
        //public string Message { get; set; }
        public BookNullException(string msg) : base(msg) { }
        //public BookNullException(string msg,BookNullException bookNullException): base(msg,bookNullException)
        //{
            
        //}
    }
}
