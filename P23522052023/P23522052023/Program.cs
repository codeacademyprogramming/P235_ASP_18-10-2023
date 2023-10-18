using System;
using System.Xml.Linq;

namespace P23522052023
{
    class Program
    {
        public static void Main(string[] args)
        {
            string word = "    Hello World P235     ";
            string word2 = "hEllO world";

            Console.WriteLine(word == word2);
            Console.WriteLine(word.ToLower() == word2.ToLower());

            Console.WriteLine(word.Contains('z'));
            Console.WriteLine(word.Contains("lo"));
            Console.WriteLine(word.IndexOf('l'));
            Console.WriteLine(word.IndexOf('l',5));
            Console.WriteLine(word.IndexOf('l',5,2));
            //int secondIndex = word.IndexOf('l', word.IndexOf('l') + 1);
            Console.WriteLine(word.IndexOf('l', word.IndexOf('l',word.IndexOf('l')+1) + 1));
            Console.WriteLine(word.IndexOf("or"));
            string lowerStrt = word.ToLower();
            //word = word.ToLower();
            Console.WriteLine(word.ToLower());
            Console.WriteLine(word);
            Console.WriteLine(lowerStrt);
            Console.WriteLine(word.ToUpper());
            Console.WriteLine(word2.Insert(0,"P235"));
            Console.WriteLine(word.LastIndexOf('l',word.LastIndexOf('l')-1));
            Console.WriteLine(word.Remove(0));
            Console.WriteLine(word.Replace('l','P'));
            Console.WriteLine(word.Replace("l","P235"));

            int firstWhite = word.IndexOf(" ");
            int secondWhite = word.IndexOf(" ",firstWhite+1);
            int inter = secondWhite - firstWhite;
            string subStr = word.Substring(firstWhite+1,inter);

            Console.WriteLine(subStr);
            Console.WriteLine(word.TrimEnd());
            Console.WriteLine(word.TrimStart());
            Console.WriteLine(word.Trim());

            //string[] words =word.Split(" ");
            //Console.WriteLine(words.Length);
            //foreach(string str in words)
            //{
            //    foreach(char sym in str)
            //    {
            //        Console.WriteLine(sym);
            //    }
            //}
            //for (int i = 5; i < words.Length; i+=3)
            //{
            //    string str = words[i];
            //    Console.WriteLine(str);
            //}

            //int count = 0;
            //for (int i = 0; i < word.Length; i++)
            //{
            //    char c = word[i];   

            //    if (c == 'l')
            //    {
            //        count++;
            //    }
            //}

            //Console.WriteLine(count);

            //char a = 'a';

            ////Console.WriteLine("Hello World \nP235");
            ////Console.WriteLine("Hello World \tP235");

            //if (char.IsNumber(a))
            //{
            //    Console.WriteLine("Reqemdir");
            //}
            //else if (char.IsDigit(a))
            //{

            //}else if (char.IsLetter(a))
            //{

            //}else if (char.IsUpper(a))
            //{

            //}else if (char.IsLower(a))
            //{

            //}else if (char.IsLetterOrDigit(a))
            //{

            //}else if (char.IsWhiteSpace(a))
            //{

            //}else if (char.IsControl(a))
            //{

            //}

            //string numStr = Console.ReadLine();

            ////int num = int.Parse(numStr);

            //int num;
            //while (!int.TryParse(numStr, out num)) 
            //{
            //    Console.WriteLine("Duzgun Daxil Et");
            //    numStr = Console.ReadLine();
            //}
            //Console.WriteLine($"Duzgundur {num}");

            //if (!int.TryParse(numStr, out num))
            //{
            //    Console.WriteLine("Duzgun Daxil Et");
            //}

            //Console.WriteLine(num);
            ////int a;

            ////int b = a;

            ////b += 100;

            ////Sum(out a);

            ////Console.WriteLine(a);

            //CheckChar(out int a);
            ////CheckChar("Hello",'l',ref int a);

            //Console.WriteLine(a);

            #region Commenyt
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            //int[] nums1 = { 10, 20, 30 };

            //int[] nums2 = nums1;

            //nums2[0] = 100;

            //Test(nums1);

            //Console.WriteLine(nums1[0]);
            //Console.WriteLine(nums2[0]);



            //byte num1 = 255;

            //int num2 = num1;

            //Console.WriteLine(num2);


            //int num3 = 566;
            //byte num4 = 0;

            //try
            //{
            //    unchecked
            //    {
            //        num4 = (byte)num3;
            //    }
            //}
            //catch (OverflowException e)
            //{

            //    Console.WriteLine(  e.Message);
            //}

            //Console.WriteLine(num4);
            //Test(age:32,num:98,surname:"Mammadov",name:"Hamid");

            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            //int a = 45;
            //int a2 = 45;
            //int a3 = 45;
            //CheckEven(45,nums);
            //CheckEven(a,nums);
            //CheckEven(545,a3,545,a,454,a2);
            #endregion
        }

        static void CheckChar(out int index, string word = "World",  char symbol = 'o')
        {
            index = -545;

            for (int i = 0; i < word.Length; i++)
            {
                //continue;

                if (word[i] == symbol)
                {
                    index = i;
                    return;
                    //break;
                }
            }

            Console.WriteLine("Tapildi");

        }

        //static void CheckChar(string word, char symbol, ref int index)
        //{
        //    index = -545;

        //    for (int i = 0; i < word.Length; i++)
        //    {
        //        //continue;

        //        if (word[i] == symbol)
        //        {
        //            index = i;
        //            return;
        //            //break;
        //        }
        //    }

        //    Console.WriteLine("Tapildi");

        //}

        //static void Sum(out int num)
        //{
        //   num = 0;
        //}

        //static void Test(int[] nums)
        //{
        //    nums[0] = 700;
        //}

        //static void CheckEven(int b,params int[] arr)
        //{
        //}

        //static void Test(int num,int age, string name, string surname) 
        //{

        //}
    }
}