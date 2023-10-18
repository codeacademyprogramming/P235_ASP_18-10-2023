using System.Text.RegularExpressions;

namespace P235Regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do 
            {
                Console.WriteLine("Email Daxil Et");
                string str = Console.ReadLine();
                Regex regex = new Regex("^[\\w]+@[A-Za-z]{3,7}.[A-Za-z]{2,3}$");
                Regex regex1 = new Regex("^[\\w]+@[A-Za-z]{3,6}.[A-Za-z]{3}.[A-Za-z]{2,3}$");
                if (regex.IsMatch(str) || regex1.IsMatch(str))
                {
                    Console.WriteLine("Dogrudu");
                }
                else
                {
                    Console.WriteLine("Yanlisdir");
                }
            } while (true);
        }
    }
}