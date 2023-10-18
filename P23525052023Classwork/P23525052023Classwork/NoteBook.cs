using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23525052023Classwork
{
    internal class NoteBook
    {
        public string Brand;
        public string Model;
        public double Price;

        public NoteBook(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Brand: {Brand}\nModel: {Model}\nPrice: {Price}");
        }
    }
}
