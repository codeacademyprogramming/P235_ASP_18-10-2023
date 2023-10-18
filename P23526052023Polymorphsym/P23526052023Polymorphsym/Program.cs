namespace P23526052023Polymorphsym
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human();
            human.Name = "Test";
            human.SurName = "Testov";
            human.GetFullInfo();
            //Console.WriteLine(human.GetFullInfo());

            Student student = new Student();
            student.Name = "Test-s";
            student.SurName = "Testov-s";
            student.Grade = 1;
            student.GetFullInfo();
            //Console.WriteLine(student.GetFullInfo());
        }
    }
}