using System.Threading;

namespace P235SynchronAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Thread
            //Thread thread1 = new Thread(Loop1);
            //Thread thread2 = new Thread(Loop2);

            //thread1.Start();
            //thread2.Start();

            //for(int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine($"Main: {i} Id:{Thread.CurrentThread.ManagedThreadId}");
            //}
            #endregion

            //long result = 0;

            //Task task = Task.Run(() =>
            //{
            //    for (long i = 0; i < 9999999999; i++)
            //    {
            //        result += i;
            //    }
            //});

            //await task;

            //Console.WriteLine(result);
            //Console.WriteLine("Hello World");
        }



        #region Thread
        //static void Loop1()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Console.WriteLine($"Loop1: {i} Id:{Thread.CurrentThread.ManagedThreadId}");
        //    }
        //}

        //static void Loop2()
        //{
        //    Thread.Yield();
        //    for (int i = 0; i < 100; i++)
        //    {

        //        Console.WriteLine($"Loop2: {i} Id:{Thread.CurrentThread.ManagedThreadId}");
        //    }
        //}
        #endregion
    }
}