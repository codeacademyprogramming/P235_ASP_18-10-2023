// See https://aka.ms/new-console-template for more information
using P23531052023Lesson;

Academy academy = new Academy();
Test test = new Test();

Academy academy1 = (Academy)test;
int b = 234324;
double a = b;


//Area area = new Area(78,63);
//Console.WriteLine(area.Calculate());

//Area area1;

////UpCasting(Boxing)
//Developer developer = new Developer();
//developer.Name = "Hamid";
//developer.SurName = "Mammadov";

//Test(developer);
//static void Test(Human obf)
//{
//    Console.WriteLine(obf.Name);
//}

//Studnet developer1 = new Developer();
//Developer developer2 = new Developer();
//Developer developer3 = new Developer();
//Developer developer4 = new Developer();

//Student student1 = new Student();
//Student student2 = new Student();
//Student student3 = new Student();
//Student student4 = new Student();
//Student student5 = new Student();

//Human[] humans = { developer1, student1 };
//object[] objects = { developer1, 1, "sad", 'a' };

//Developer developer1 = new Developer 
//{
//    Name = "Hamid",
//    SurName = "Mammadov",
//    Grade = 97,
//    Language = "CSharp"
//};

//Enginier enginier = new Enginier
//{
//    Name = "Merahim",
//    SurName = "ImamAliyev",
//    Grade = 80,
//    Experiance = 5
//};

//Teacher teacher = new Teacher
//{
//    Name = "Merahim",
//    SurName = "ImamAliyev",
//    Grade = 80,
//    Speciality = "Programming"
//};

//WriteInfo(developer1);
//WriteInfo(enginier);
//WriteInfo(teacher);
//WriteInfo(789);

//static void WriteInfo(Developer obj)
//{
//    //Implicit
//    Enginier enginier = obj;
//    Console.WriteLine($"{enginier.Experiance} {enginier.Grade}");
//}

//static void WriteInfo(Enginier obj)
//{
   

//    //Explicit
//    Developer developer = (Developer)obj;
//    Console.WriteLine(developer.Language);











//    //Wrong Way
//    //Developer student = (Developer)human;

//    //True Way With as Operator
//    //Developer developer = obj as Developer;
//    ////Console.WriteLine(developer.Language);
//    //if (developer != null)
//    //{
//    //    Console.WriteLine(developer.Language);
//    //}

//    //Enginier enginier = obj as Enginier;
//    //if (enginier != null)
//    //{
//    //    Console.WriteLine(enginier.Experiance);
//    //}

//    //int? a = obj as int?;
//    //if(a != null)
//    //{
//    //    Console.WriteLine(a);
//    //}

//    //True Way With is Operator
//    //if (obj is Developer)
//    //{
//    //    Developer student = (Developer)obj;
//    //    Console.WriteLine(student.Language);
//    //}
//    //else if (obj is Enginier)
//    //{
//    //    Enginier student = (Enginier)obj;
//    //    Console.WriteLine(student.Experiance);
//    //}
//    //else if (obj is Teacher)
//    //{
//    //    Teacher student = (Teacher)obj;
//    //    Console.WriteLine(student.Speciality);
//    //}else if(obj is int)
//    //{
//    //    Console.WriteLine();
//    //}
//}
