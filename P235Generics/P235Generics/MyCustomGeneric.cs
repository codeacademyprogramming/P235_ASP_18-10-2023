using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235Generics
{
    internal class MyCustomGeneric<T,U> where T : IMyCustomGeneric where U : class,new()
    {
        private T[] _arr;

        public MyCustomGeneric()
        {
            _arr = new T[0];
        }

        public void Add(T num)
        {
            Array.Resize(ref _arr, _arr.Length + 1);
            _arr[_arr.Length - 1] = num;
        }

        public T Get(int index)
        {
            return _arr[index];
        }
    }
}
