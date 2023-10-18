namespace P23530052023HomeWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User Name - i Daxil Et");
            string userName = Console.ReadLine();
            Console.WriteLine("Password - u Daxil Et");
            string password = Console.ReadLine();

            User user = new User(userName);
            user.Password = password;
        }
    }
}