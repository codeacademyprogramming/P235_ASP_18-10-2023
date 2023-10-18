using System.Collections;
//using System.Collections.Generic;

namespace P235Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Non Generic Type
            //Non-Generic Collection
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1);
            //arrayList.Add("test");
            ////int? a = (int?)arrayList[1] as int?;
            ////arrayList.Clear();
            ////arrayList.Remove("test");
            //ArrayList arrayList2 = new ArrayList();
            //arrayList2.Add(2);
            //arrayList2.AddRange(arrayList);

            ////arrayList2.Contains(2);
            ////arrayList2.IndexOf(2);
            //arrayList2.Insert(5, 3);

            //foreach (var i in arrayList2)
            //{
            //    Console.WriteLine(i);
            //}

            //SortedList sortedList = new SortedList();

            //sortedList.Add("salam",9);
            //sortedList.Add("P235",7);
            //sortedList.Add("Hello",4);

            //foreach(var i in sortedList.Values) 
            //{
            //    Console.WriteLine(i);
            //}

            //FIFO - First In First Out
            //Queue queue = new Queue();
            //queue.Enqueue(1);
            //queue.Enqueue("P235");
            //queue.Enqueue('Z');

            //Console.WriteLine(queue.Peek());
            //var a = queue.Dequeue();
            //Console.WriteLine(queue.Peek());
            //Console.WriteLine($"Count: {queue.Count}");
            //Console.WriteLine(queue.Dequeue());
            //Console.WriteLine($"Count: {queue.Count}");
            //Console.WriteLine(queue.Dequeue());

            //LIFO - Last In First Out
            //Stack stack = new Stack();
            //stack.Push(1);
            //stack.Push("P235");
            //stack.Push('z');

            //Console.WriteLine($"Count: {stack.Count}");
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine($"Count: {stack.Count}");
            //Console.WriteLine(stack.Pop());

            //Console.WriteLine(stack.Peek());
            #endregion

            #region Generic Type Collection
            #region List
            //List<int> list = new List<int>();
            //list.Add(15);
            //list.Add(2);
            //list.Add(3);
            //list.Clear();
            //list.Remove(15);
            ////list.RemoveAt(15);
            //foreach (int i in list)
            //{

            //}
            //Console.WriteLine(list[0]);

            //CustomCollection<int> customCollection = new CustomCollection<int>();
            //customCollection.Add(15);
            //customCollection.Add(25);
            //customCollection.Add(35);
            //customCollection[1] = 5;
            //Console.WriteLine(customCollection[0]);
            //foreach (int i in customCollection)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion
            #region SortedList
            //SortedList<string,int> sorted = new SortedList<string, int> ();

            //sorted.Add("a", 1);
            //sorted.Add("b", 2);
            //sorted.Add("C", 3);

            //foreach (var item in sorted.Values)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Dictionary
            //Dictionary<string, int> dic = new Dictionary<string, int>();
            //dic.Add("a", 1);
            //dic.Add("C", 11);
            //dic.Add("B", 111);

            //foreach (var item in dic)
            //{
            //    Console.WriteLine($"Key: {item.Key} = Value: {item.Value}");
            //}
            #endregion
            #region Queue
            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(1);
            //queue.Dequeue();
            //queue.Peek();
            #endregion
            #region Stack
            //Stack<int> stack = new Stack<int>();
            //stack.Push(1);
            //stack.Pop();
            //stack.Peek();
            #endregion
            #endregion

            #region Delegate
            int[] arr = { 5, 10, 11, 13, 22, 35, 12, 45 };

            //Console.WriteLine(Sum(arr, IsEven));
            //Console.WriteLine(Sum(arr, IsOdd));
            //Anonym Method
            //Console.WriteLine(Sum(arr,
            //delegate (int asd, int aasd) 
            //{
            //    return asd % 4 == 0;
            //}));
            ////Lambda Expression
            //Console.WriteLine(Sum(arr, (n,a) => n%9==0 ));
            //Console.WriteLine(Sum(arr, (a,b) =>
            //{
            //    return a % 9 == 0;
            //}));
            //List<int> list = new List<int>();
            //list.Add(5);
            //list.Add(7);
            //list.Add(8);
            //list.Add(15);
            //list.Add(12);
            //list.Add(25);

            //foreach (var item in list.FindAll(IsDevideByFive))
            //{
            //    Console.WriteLine(item);
            //}

            //Check check = new Check(IsEven);
            //check += IsOdd;
            //check += IsDevideByFive;
            //check -= IsDevideByFive;
            //check -= IsOdd;
            //Console.WriteLine(check.Invoke(78));
            //Console.WriteLine(check.Invoke(78));
            //Console.WriteLine(check.Invoke(78));
            
            Write write = delegate (string strin) 
            {
                Console.WriteLine(strin.ToLower());
            };
            write += ToUpper;

            write += Replace;
            write += s => Console.WriteLine(s+=" P235");

            Test(write);
            #endregion
        }

        static void Test(Write write)
        {
            write -= s => Console.WriteLine(s += " P235");
            //write -= delegate (string strin)
            //{
            //    Console.WriteLine(strin.ToLower());
            //};
            write.Invoke("Hello Code Academy");
        }

        static void ToUpper(string str)
        {
            Console.WriteLine(str.ToUpper());
        }

        static void Replace(string str)
        {
            Console.WriteLine(str.Replace("a", "P235"));
        }

        //static int Sum(int[] array, Check1 check)
        //{
        //    int result = 0;

        //    foreach (int item in array)
        //    {
        //        //if (check(item))
        //        //{
        //        //    result += item;
        //        //}
        //    }

        //    return result;
        //}

        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        static bool IsOdd(int num)
        {
            return num % 2 != 0;
        }

        static bool IsDevideByFive(int num)
        {
            return num % 5 == 0;
        }

        //static int SumEven(int[] array)
        //{
        //    int result = 0;

        //    foreach (int item in array)
        //    {
        //        if (IsEven(item))
        //        {
        //            result += item;
        //        }
        //    }

        //    return result;
        //}



        //static int SumOdd(int[] array)
        //{
        //    int result = 0;

        //    foreach (int item in array)
        //    {
        //        if (IsOdd(item))
        //        {
        //            result += item;
        //        }
        //    }

        //    return result;
        //}



        //static int SumDevideByFive(int[] array)
        //{
        //    int result = 0;

        //    foreach (int item in array)
        //    {
        //        if (IsDevideByFive(item))
        //        {
        //            result += item;
        //        }
        //    }

        //    return result;
        //}


    }
}