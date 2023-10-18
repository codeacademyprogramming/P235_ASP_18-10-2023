using System.Linq;

namespace P235Delegate
{
    internal class Program
    {
        //public int MyProperty { get => 5 set; }

        static void Main(string[] args)
        {
            Predicate<int> predicate = IsEven;
            Func<int,bool> func = IsEven;
            List<int> list = new List<int>();
            //list.FindAll(n => n % 2 == 0 || n% 4==0);
            //Action<int,double> action = Test;

            //Test();

            //Func<double> func = Test;
            //func += delegate ()
            //{
            //    double a = 5;
            //    return a;
            //};
            //func += () => 5;

            //Func<int,string bool> func1 = IsOdd;
        }

        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        static void Test( )
        {
            Console.WriteLine("Test");
        }
        static void Test(int a)
        {

        }

        static void Test(int a , int b)
        {

        }
        //static bool IsOdd(string a ,int num)
        //{
        //    return (num % 2 == 0);
        //}
        //static double Test() => 5;

        //static int Test(string name)
        //{
        //    return 0;
        //}

        static long Test(int num, double d)
        {
            return (long)num;
        }
    }
}