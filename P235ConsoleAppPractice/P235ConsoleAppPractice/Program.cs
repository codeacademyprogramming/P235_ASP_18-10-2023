using P235ConsoleAppPractice.Interfaces;
using P235ConsoleAppPractice.Models;
using P235ConsoleAppPractice.Services;

namespace P235ConsoleAppPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread.CurrentThread.CurrentCulture =new System.Globalization.CultureInfo("az-Lat-AZ");

            ICourseManagerService courseManagerService = new CourseManagerService();

            do
            {
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Nomresini Daxil Edin\n");
                Console.WriteLine("1 - Qrupdaki telebelerin siyahisini goster");
                Console.WriteLine("2 - Butun telebelerin siyahini goster");
                Console.WriteLine("3 - Telebe elave et");
                Console.WriteLine("4 - Tarix aralığına görə tələbərlə bax");
                Console.WriteLine("5 - Umumi axtaris");
                Console.WriteLine("6 - Tələbənin qrupunu dəyiş");
                Console.WriteLine("7 - Seçilmiş tələbəni sil ");
                Console.WriteLine("8 - Secilmis qrupun ortalama balina bax");

                string option = Console.ReadLine();
                int op;

                while (!int.TryParse(option,out op) || op < 1 || op > 8)
                {
                    Console.WriteLine("Duzgun Daxil Et");
                    option = Console.ReadLine();
                }

                switch (op)
                {
                    case 1:
                        GetStudentsByGroupNo(ref courseManagerService);
                        break;
                    case 2:
                        ShowAllStudents(ref courseManagerService);
                        break;
                    case 3:
                        AddStudent(ref courseManagerService);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                }
            } while (true);
        }

        static void GetStudentsByGroupNo(ref ICourseManagerService courseManagerService)
        {
            Console.Clear();

            Console.WriteLine("Qrup Nomresini Daxil Et");
            string groupNo = Console.ReadLine();

            Student[] students = courseManagerService.GetStudentsByGroupNo(groupNo);

            if (students.Length > 0)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Daxil etdiyniz Qrup Nomresine Uygun Tapilmadi");
                Console.ResetColor();
            }
        }

        static void ShowAllStudents(ref ICourseManagerService courseManagerService)
        {
            Console.Clear();

            foreach (Student student in courseManagerService.Students)
            {
                Console.WriteLine(student);
            }
        }

        static void AddStudent(ref ICourseManagerService courseManagerService)
        {
            Console.Clear();

            Console.WriteLine("Telebenin Ad Soyadini Daxil");
            string fullName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine("Duzgun Ad Soyad Daxil");
                fullName = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Qrupunu Daxil Et");
            string groupNo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(groupNo))
            {
                Console.WriteLine("Duzgun Qrup Daxil Et");
                groupNo = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Qiymetini Daxil Et");
            string pointStr = Console.ReadLine();
            double point;

            while (!double.TryParse(pointStr,out point) || point < 0)
            {
                Console.WriteLine("Duzgun Qiymet Daxil Et");
                pointStr = Console.ReadLine();
            }

            Console.WriteLine("Baslama Tarixini Daxil Et\nExample: yyyy/MM/dd");
            string startDateStr = Console.ReadLine();
            DateTime startdate;
            while (!DateTime.TryParse(startDateStr,out startdate))
            {
                Console.WriteLine("Duzgun Tarix Daxil Et");
                startDateStr = Console.ReadLine();
            }

            Student student = new Student 
            {
                FullName = fullName,
                GroupNo = groupNo,
                Point = point,
                StartDate = startdate
            };

            courseManagerService.AddStudent(student);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Telebe Ugurla Elave Olundu");
            Console.ResetColor();
        }
    }
}