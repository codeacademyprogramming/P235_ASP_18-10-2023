using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23530052023HomeWorkd3
{
    internal static class Extention
    {
        public static void CheckStrLength(this string str)
        {
            if(str.Length > 8)
            {
                Console.WriteLine("Uygundur");
            }
            else
            {
                Console.WriteLine("Uygun Deyil");
            }
        }

        public static bool CheckSymbolInString(this string str,char letter)
        {
            return str.Contains(letter);
        }

        public static bool CheckSymbolInString(this string str, string letter)
        {
            return str.Contains(letter);
        }
    }
}
