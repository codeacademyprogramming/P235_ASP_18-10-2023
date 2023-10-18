using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23530052023HomeWorkd3
{
    //Static Keywordune Sahib Class-in Daxilinde Butun Memberler Hemcinin Constructor-da Statict
    //Static Keywordune Sahib Class-dan instance(object) yaradila bilmir
    internal class Product
    {
        //public static int no;
        //public static string TestStatic { get; set; }
        private static int _no;

        public string Name;
        public double Price;
        public double DiscountedPrice;
        public int TotalCount;
        public string Code;
        //public string Seria;
        //public int No;
        public ProductType ProductType;

        static Product()
        {
            _no = 1000;
        }

        public Product(double price, ProductType productType)
        {

            _no++;

            Price = price;
            ProductType = productType;
            Code = $"{productType.ToString()[0]}{_no}";
            DiscountedPrice = productType == ProductType.Bakery ? Price * 0.9 : 0;

            //if (productType == ProductType.Bakery)
            //{
            //    DiscountedPrice = Price * 0.9;
            //}

            //switch (productType)
            //{
            //    case ProductType.Bakery:
            //        Code = "B"+_no;
            //        DiscountedPrice = Price * 0.9;
            //        break;
            //    case ProductType.Drink:
            //        Code = "D";
            //        break;
            //    case ProductType.Meat:
            //        Code = "M";
            //        break;
            //    case ProductType.Fish:
            //        Code = "F";
            //        break;
            //    default:
            //        break;
            //}

            //switch (productType)
            //{
            //    case ProductType.Bakery:
            //        Seria = "B";
            //        break;
            //    case ProductType.Drink:
            //        Seria = "D";
            //        break;
            //    case ProductType.Meat:
            //        Seria = "M";
            //        break;
            //    case ProductType.Fish:
            //        Seria = "F";
            //        break;
            //    default:
            //        break;
            //}
        }

        //public static void StaticMethod()
        //{
        //    no = 1000;
        //    TestStatic = "";
        //    Console.WriteLine("Static Method");
        //}

        //public void NonStaticMethod()
        //{
        //    StaticMethod();
        //}

    }
}
