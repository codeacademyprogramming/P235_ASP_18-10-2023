namespace P235Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { };

            //double[] nums2 = { };

            //MyCustomGeneric<int> myCustomGeneric1 = new MyCustomGeneric<int>();
            //myCustomGeneric1.Add(1);
            //Console.WriteLine(myCustomGeneric1.Get(0));
            //MyCustomGeneric<double> myCustomGeneric2 = new MyCustomGeneric<double>();
            //myCustomGeneric2.Add(2.3);
            //Console.WriteLine(myCustomGeneric2.Get(0));

            //MyCustomGeneric<Human> myCustomGeneric3 = new MyCustomGeneric<Human>();
            //myCustomGeneric3.Add();
            //Console.WriteLine(myCustomGeneric3.Get(0));


        }

        static void AddNumToArr<T>(ref T[] arr, T num) where T : class
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = num;
        }

        //static int GetNumFromArr(int[] arr, int index)
        //{
        //    return arr[index];
        //}

        //static void AddNumToArr(ref double[] arr, double num)
        //{
        //    Array.Resize(ref arr, arr.Length + 1);
        //    arr[arr.Length - 1] = num;
        //}

        //static double GetNumFromArr(double[] arr, int index)
        //{
        //    return arr[index];
        //}
    }
}