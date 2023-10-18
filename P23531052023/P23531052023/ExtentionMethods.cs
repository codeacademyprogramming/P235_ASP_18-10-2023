using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23531052023
{
    internal static class ExtentionMethods
    {
        public static bool IsOdd(this int num)
        {
            if(num%2 != 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsContainsDigit(this string str) 
        {
            foreach (char c in str) 
            {
                if (char.IsDigit(c)) 
                {
                    return true;
                    
                }
            }
            return false;
        }
        public static string ToCapitalize(this string str)
        {
            StringBuilder sb = new StringBuilder();

            if (str.Length == 0)
            {
                Console.WriteLine("String bosdur");
            }
            else if (str.Length == 1)
            {
                sb.Append(char.ToUpper(str[0]));
            }
            else
            {
                sb.Append((char.ToUpper(str[0]) + str.Substring(1)));
            }



            return sb.ToString();
        }

        public static int[] GetValueIndex(this string str, char ch)
        {
            int[] arr = { };

            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = i;
                }
            }
            return arr;
        }
    }

}
