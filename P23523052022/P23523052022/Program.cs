using System.Text;
namespace P23523052022
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Soz Daxil Et:");
            //string word = "Hello World P235";
            ////string rStr = ReverseStr(word);

            //string[] words = word.Split(' ');
            //string rStr = String.Join(' ', words);
            //Console.WriteLine(rStr);

            //int[] nums = { 4, 54, 6, 68, 4, 32 };
            ////int num = nums.Max();
            ////int num = nums.Min();
            ////double num = nums.Average();
            //bool num = nums.Contains(65);
            //Console.WriteLine(num);

            //string[] words = { "test", "Salam" };
            //Array.Resize(ref words, 7);

            //words[2] = "P235";
            //words[3] = "Hello1";
            //words[4] = "Hello2";
            //words[5] = "Hello3";
            //words[6] = "Hello4";


            //foreach (string word in words)
            //{
            //    Console.WriteLine(word);
            //}
            //int index = Array.IndexOf(words, "test");
            //Console.WriteLine(index);

            //string[] words = { "test", "Salam","Hamid","Merahim","Ferid","Murad" };

            //int[] nums = { 45, 21, 1, 354, -65,'b' };
            ////Array.Reverse(words);
            //Array.Sort(nums);


            //foreach (int word in nums)
            //{
            //    Console.WriteLine(word);
            //}

            //string[] newArr = { };
            //string[] newArr = new string[0];
            //foreach (string word in words)
            //{
            //    if (word.Length > 4)
            //    {
            //        Array.Resize(ref newArr, newArr.Length + 1);
            //        newArr[newArr.Length-1] = word;
            //        //int leng = newArr.Length;
            //        //leng++;
            //        //Array.Resize(ref newArr, leng);
            //        //int lastIndex = leng - 1;
            //        //newArr[lastIndex] = word;
            //    }
            //}

            int[] nums = { 564, 64, 65, 664, 6, 464, 4, 67, 5, 4 };

            Console.WriteLine("After Sort");
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("===================\n");
            Console.WriteLine("Befor sort");
            Array.Sort(nums);
            Array.Reverse(nums);
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }
        }

        static string ReverseStr(string word)
        {
            string[] words = word.Split(' ');
            StringBuilder reve = new StringBuilder();

            //string reversedStr = "";
            foreach (string item in words)
            {
                for (int i = item.Length - 1; i >= 0; i--)
                {
                    reve.Append(item[i]);
                }

                if (item != words[words.Length - 1])
                {
                    reve.Append('-');
                }
            }

            return reve.ToString();

            //Console.WriteLine(  reversedStr);
        }

        //static string ReverseStr(string str)
        //{
        //    string reversedStr = "";

        //    for (int i = str.Length-1;i>=0;i--)
        //    {
        //        reversedStr += str[i];
        //    }

        //    return reversedStr;
        //}
    }
}