using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235Collection
{
    internal class CustomCollection<T> : IEnumerable
    {
        private T[] array;
        //Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                {
                    throw new IndexOutOfRangeException("Gonderdiyniz Index Yanlisdir");
                }
                return array[index]; 
            }
            set 
            {
                if (index < 0 || index >= array.Length)
                {
                    throw new IndexOutOfRangeException("Gonderdiyniz Index Yanlisdir");
                }
                array[index] = value; 
            }
        } 
        public CustomCollection()
        {
            array = new T[0];
        }

        //public int Test()
        //{
        //    throw new IndexOutOfRangeException();

        //    return 1;
        //}

        public void Add(T item)
        {
            Array.Resize(ref array, array.Length +1);
            array[array.Length-1] = item;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}
