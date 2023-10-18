using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235ClassWork13062023.Models
{
    internal class Book
    {
        private static int _code;
        public string Code;
        public string Name;
        public string AuthorName;
        public int PageCount;

        public Book(string name, string authorName, int pageCount)
        {
            _code++;
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
            Code = $"{Name.Substring(0, 2).ToUpper()}{_code}";
        }

        static Book()
        {
            _code = 0;
        }
    }
}
