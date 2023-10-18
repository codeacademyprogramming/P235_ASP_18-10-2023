namespace P23530052023HomeWorkd3
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "Helo World";

            Extention.CheckStrLength(word);

            word.CheckStrLength();
            Console.WriteLine(word.CheckSymbolInString('a')); 

            //Product.no = 235;
            //Product.TestStatic = "P235";

            //Console.WriteLine(Product.no);

            //Product product1 = new Product(123, ProductType.Bakery);
            //Product product2 = new Product(123, ProductType.Bakery);
            //Product product3 = new Product(123, ProductType.Bakery);
            //Product product4 = new Product(123, ProductType.Bakery);

            //Console.WriteLine(product1.No);
            //Console.WriteLine(product2.No);
            //Console.WriteLine(product3.No);
            //Console.WriteLine(product4.No);

            //Product.StaticMethod();

            //Product[] products = { };

            //Product product = new Product(10,ProductType.Bakery);

            //if(products.Length == 0)
            //{
            //    product.No = 1000;
            //}
            //else
            //{
            //    product.No = products[products.Length - 1].No + 1;
            //}
        }
    }
}