using System;

namespace P23531052023 
{ 
    class Program
    {
        static void Main(string[] args)
        {
            int a = 555;
            int b = 444;
            Console.WriteLine(a.IsOdd());
            Console.WriteLine(b.IsOdd());
            string str1 = "Hello World";
            string str2 = "P235";
            Console.WriteLine(str1.IsContainsDigit());
            Console.WriteLine( str2.IsContainsDigit());
            string abc = "abc";
            string c = "masin";
            Console.WriteLine(abc.ToCapitalize());
            Console.WriteLine(c.ToCapitalize());

            string str3 = "hello";
            foreach (int item in str3.GetValueIndex('l'))
            {
                Console.WriteLine( item);
            }
           
        }
    }
}

