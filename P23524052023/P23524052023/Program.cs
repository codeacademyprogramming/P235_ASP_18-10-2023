using System;
using static System.Net.Mime.MediaTypeNames;

namespace P23524052023
{
    class Program
    {
        static void Main(string[] args)
        {
            Math math = new Math(15, 30);
            Console.WriteLine(math.Sum());
            Console.WriteLine(math.Multiple());
            Console.WriteLine(math.Devide().ToString("F2"));

            //Student student1 = new Student("Hamid", "Mammadov", 32);
            ////student1.FullInfo();

            //Student student2 = new Student("Hamid", "Mammadov", 32);
            ////student2.FullInfo();

            //Student student3 = new Student("Hamid", "Mammadov", 32);
            ////student3.FullInfo();

            //Student student4 = new Student("Hamid", "Mammadov", 32);
            //student4.FullInfo();
            //string a1 = "Hello";
            ////   instance(object)  =  Initialze
            //Student stu1 = new Student("Hamid-c","Mammadov-c");
            ////Console.WriteLine($"{stu1.Name} {stu1.SurName}");


            ////Set Values
            //stu1.Name = "Hamid";
            //stu1.SurName = "Mammadov";
            //stu1.Age = 32;
            //stu1.Name = "Test";
            ////Get Values
            //string a = stu1.Name;

            //Student stu2 = stu1;
            //stu2.Name = "P235";
            //Test(stu2);
            ////Console.WriteLine(stu1.Name);
            ////Console.WriteLine(stu2.Name);

            //Student stu3 = new Student("Merahim","ImamAliyev");
            //Console.WriteLine($"{stu1.Name} {stu1.SurName}");
            //Console.WriteLine($"{stu3.Name} {stu3.SurName}");
            //Anonym Object
            //var stu1 = new
            //{
            //    name = "Hamid",
            //    surname = "Mammadov",
            //    age = 30,
            //    grade = 30
            //};

            //var stu2 = new 
            //{
            //    name = "Hamid",
            //    surname = "Mammadov",
            //    age = 30,
            //    grade = 30
            //};

            //var stu3 = new
            //{
            //    name = "Hamid",
            //    surname = "Mammadov",
            //    age = 30
            //};
            //Built In Type
            //int a = 5;
            //int b = 15;

            //student.name = "asdads";
            //string a = student.name;
            //Console.WriteLine($"Adi: {student.name}\nSoyAdi: {student.surname}");

            //string name = "Hamid";


            //string surName = "Mammadov";


            //string name1 = "Merahim";

            //string surName1 = "ImamAliyev";

            #region DateTime
            //Console.WriteLine(DateTime.Now.ToString("MMMM - yy"));
            //Console.WriteLine(DateTime.Now.ToString("HH / mm"));
            //Console.WriteLine(DateTime.Now.Month);
            //Console.WriteLine(DateTime.Now.Year);
            //Console.WriteLine(DateTime.UtcNow.AddHours(-4));

            //DateTime dateTime = DateTime.Now;
            //DateTime dateTime1 = DateTime.UtcNow.AddHours(3);

            //if (dateTime > dateTime1)
            //{
            //    Console.WriteLine("DateTime Boyukdur");
            //}
            //else
            //{
            //    Console.WriteLine("Boyuk Deyil");
            //}

            //int age = 2009;

            //if ((DateTime.Now.Year - age) >= 18)
            //{

            //}
            #endregion
            #region NullAble
            //int? a = null;
            //byte? b = null;
            //if (a != null)
            //{

            //}
            #endregion
            #region Enum
            //Console.WriteLine("Ay Sec: Ayın Önündəki Rəqəmi Daxil Et");

            //foreach (var item in Enum.GetValues(typeof(Monthh)))
            //{
            //    Console.WriteLine($"{(byte)item} {item}");
            //}
            //neisdesen:
            //string numStr = Console.ReadLine();
            //byte num;

            //while (!byte.TryParse(numStr, out num))
            //{
            //    Console.WriteLine("Duzgun Reqem Daxil");
            //    numStr = Console.ReadLine();
            //}

            //if (num <= 0 || num > 4)
            //{
            //    Console.WriteLine("Reqemi Duzgun Daxil");
            //    goto neisdesen;
            //}

            //Console.WriteLine($"Seçdiyniz Ay: {(Monthh)num} {num}");
            #endregion
        }

        static void Test(Student student)
        {
            student.Name = "Test";
        }
    }

    //enum Month : byte
    //{ 
    //    Yanvar=1,
    //    Fevral,
    //    Mart,
    //    Aprel
    //}

}