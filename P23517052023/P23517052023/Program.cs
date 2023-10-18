namespace P23517052023
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = { 5, 7, 15, 17 };

            int i = 0;

            int num1 = 5;

            int num2 = 0;

            //while (i <= nums.Length)
            //{
            //    Console.WriteLine(nums[i]);

            //    i++;
            //}

            try
            {
                Console.WriteLine(num1 / num2);

                while (i <= nums.Length)
                {
                    Console.WriteLine(nums[i]);

                    i++;
                }
            }
            catch (IndexOutOfRangeException)
            {

                Console.WriteLine("Index Yanlisdir");
            }catch (DivideByZeroException)
            {
                Console.WriteLine("Sifira Bolme Ola Bilmez");
            }catch(Exception) 
            {
                Console.WriteLine("error bas verdi");
            }

            

            //int[] nums = new int[5];
            //int[] nums = new int[5] { 5,7,15,17,18 };
            //int[] nums = { };

            //int lastIndex = nums.Length - 1;

            //Console.WriteLine(nums[lastIndex]);


            //string[] names = { "Hamid","Suraj"};

            //int num = 5;

            //for (int i = 0; i < num; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}


            //int i = 9;
            //int j = 9;

            //while (i < num)
            //{
            //    if(i % 2 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }

            //    i++;
            //}

            //do
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }

            //    i++;
            //}
            //while (i < num);

            //while (i < 10)
            //{
            //    Console.WriteLine("Hello World While");
            //    i++;
            //}

            //do
            //{
            //    Console.WriteLine("Hello World do While");
            //    j++;

            //} while (j < 10);


            //if (num == 50)
            //{
            //    //num /= 5;
            //}
            //if(num > 50)
            //{
            //    //num /= 4;
            //}
            //else if (num < 30)
            //{
            //    num /= 4;
            //}
            //else if (num > 20)
            //{
            //    num /= 4;
            //}
            //else if (num == 10)
            //{
            //    num /= 4;
            //}
            //else
            //{
            //    Console.WriteLine("Ondenmedi");
            //}
            //num = 0;

            //switch (num)
            //{
            //    case 50:
            //        num /= 5;
            //        break;
            //    case 40:
            //        num /= 4;
            //        break;
            //    case 30:
            //        num /= 3;
            //        break;
            //    case 20:
            //        num /= 2;
            //        break;
            //    case 10:
            //        num /= 1;
            //        break;
            //    default:
            //        Console.WriteLine("Switch Odenmedi");
            //        break;
            //}

        }
    }
}