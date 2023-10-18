using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235Inheritance
{
    internal class Human 
    {
        readonly string Name;

        string Test { get; }


        byte _age;

        public byte Age 
        {
            //Propertinin Accessorlari (Methodlardi)
            get 
            {
                return _age;
            }
            protected set
            {
                if (value > 18 && value < 50)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Duzgun Yas Daxil Et");
                }
            }
        }

        #region Encapsulate Name Old Version
        //private string Name;
        //public void SetName(string name)
        //{
        //    if (name.Length > 3)
        //    {
        //        Name = name;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Duzgun Ad Daxil Et");
        //    }

        //}
        //public string GetName()
        //{
        //    return Name;
        //}
        #endregion
        public string SurName;

        //public Human(string name)
        //{
        //    Test = name;
        //    Name = name;
        //    Console.WriteLine("Hello Human");
        //}

        //public Human(string name) : this() 
        //{
        //    //Name = name;
        //}
        #region Encapsulate Age Old Version
        //private byte Age;
        //public void SetAge(byte age)
        //{
        //    if (age > 18 && age < 50)
        //    {
        //        Age = age;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Duzgun Yas Daxil Et");
        //    }
        //}

        //public byte GetAge()
        //{
        //    return Age;
        //}
        #endregion

        //protected void TestMethod(string a)
        //{
        //    if (Name.Length > 3)
        //    {
        //        Name = a;
        //    }
        //}
    }
}
