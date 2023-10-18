namespace P235Method
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num1 = GetNum();
            int num2 = GetNum();

            int max = GetMax(num1, num2);
            int min = GetMin(num1, num2);

            GetEvenAnInterval(min,max);

            //string name = "Hamid";
            //string surname = "Mammadov";

            //string test = "";

            //for (int i = name.Length-1; i >= 0; i--)
            //{
            //    test+= name[i];
            //}

            //Console.WriteLine(test);

            //for (int i = 0; i < name.Length; i++)
            //{
            //    Console.WriteLine(name[i]);
            //}
            //int age = 32;
            //Console.WriteLine(name+" "+surname+age);

            //string test = "";
            //test += name[0];
            //Console.WriteLine(test);

            //P235Method();
            //int num = Compare();

            //Sum(35.3, 35.6,366);
        }

        static int GetNum()
        {
            Console.WriteLine("Reqemi Daxil Et");
            string numStr = Console.ReadLine();
            int num = Convert.ToInt32(numStr);

            return num;
        }

        static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        static int GetMin(int num1, int num2)
        {
            if(num1 < num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        static void GetEvenAnInterval(int min, int max)
        {
            while (min <= max)
            {
                if (min % 2 == 0)
                {
                    Console.WriteLine(min);
                }

                min++;
            }
        }

        //static void Sum(int num1, int num2)
        //{
        //    Console.WriteLine(num1+num2);
        //}

        //static void Sum(double num1, double num2)
        //{

        //}

        //static void Sum(double num1, int num2)
        //{

        //}

        //static void Sum(double num1, double num2,double num3)
        //{

        //}

        //static void P235Method()
        //{

        //    int num1 = GetNum();


        //    int num2 = GetNum();

        //    int result = num1 + num2;
        //    Console.WriteLine(result);

        //}

        //static void Calculate(int n1, int n2) 
        //{
        //    Console.WriteLine(n1 * n2);
        //}

        //static int Compare()
        //{
        //    int num1 = GetNum();
            
        //    int num2 = GetNum();

        //    if (num1 > num2)
        //    {
        //        return num1;
        //    }
        //    else
        //    {
        //        return num2;
        //    }
        //}

        //static void SumOfNum(string str, int num)
        //{
        //    int result = 0;
        //    int modul = 0;

        //    while (num > 0)
        //    {
        //        modul = num % 10;
        //        num = (num - modul) / 10;
        //        result += modul;
        //    }

        //    Console.WriteLine(result);
        //}

        //static int GetNum()
        //{
        //    Console.WriteLine("Reqemi Daxil Et");
        //    string strNum1 = Console.ReadLine();
        //    int num1 = Convert.ToInt32(strNum1);

        //    return num1;
        //}


    }
}