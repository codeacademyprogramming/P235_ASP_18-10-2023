namespace P23524052023
{
    //Custom Type
    class Student
    {
        //Constructr(Method)
        //public Student(string tes)
        //{
        //    Console.WriteLine("Constructr isledi "+tes);
        //}

        //public Student(int tes)
        //{
        //    Console.WriteLine("Constructr isledi " + tes);
        //    Age = tes;
        //}
        public Student()
        {
            
        }
        public Student(string name) : this()
        {
            Name = name;
        }

        public Student(string name, string surname) : this(name)
        {
            //Name = name;
            SurName = surname;
        }
        public Student(string name, string surname, int age) : this(name,surname)
        {
            //Name = name;
            //SurName = surname;
            Age = age;

            FullInfo();
        }
        //Members
        //Field
        public string Name;
        public string SurName;
        public int Age;

        public void FullInfo()
        {
            Console.WriteLine($"Adı: {Name}\nSoyAdi: {SurName}\nYasi: {Age}");
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