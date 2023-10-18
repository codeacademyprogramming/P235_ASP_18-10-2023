namespace P23530052023HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Engineer[] engineers = { };

            do
            {
                Console.WriteLine("============Etmek Isdediyniz Emeliyyatin Nomresini Daxil Et==========");
                Console.WriteLine("1. Işçi Əlavə Et");
                Console.WriteLine("2. Maas Ortalamani Gosder");
                Console.WriteLine("3. Cixis");

                string opStr = Console.ReadLine();
                int op;
                while (!int.TryParse(opStr,out op) || op < 1 || op > 3)
                {
                    Console.WriteLine("Duzgun Daxil Et");
                    opStr = Console.ReadLine();
                }

                switch (op)
                {
                    case 1:
                        AddEngineer(ref engineers);
                        break;
                    case 2:
                        CalculateAvgSalary(ref engineers);
                        break; 
                    case 3:
                        return;
                }


            } while (true);
        }

        static void AddEngineer(ref Engineer[] engineers)
        {
            Console.WriteLine("Iscinin Ad Soyadini Daxil Edin");
            string fullName = Console.ReadLine();
            Console.WriteLine("iscinin Maasini Daxil Et");
            string salaryStr = Console.ReadLine();
            double salary;
            while (!double.TryParse(salaryStr, out salary))
            {
                Console.WriteLine("Duzgun Maas Daxil Et");
                salaryStr = Console.ReadLine();
            }

            Engineer engineer = new Engineer(salary, fullName);

            Array.Resize(ref engineers, engineers.Length + 1);
            engineers[engineers.Length - 1] = engineer;
        }
        static void CalculateAvgSalary(ref Engineer[] engineers)
        {
            double totalSalay = 0;
            foreach (Engineer eng in engineers)
            {
                totalSalay += eng.Salary;
            }

            double avgSalary = totalSalay / engineers.Length;
            Console.WriteLine($"Ortalama Maas: {avgSalary}");
        }
    }
}