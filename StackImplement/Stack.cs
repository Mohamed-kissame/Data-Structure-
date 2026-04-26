using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImplement
{
    public class Stack<T>
    {

        private T[] _Storage;
        private int _Count;
        private int _Capacity;


        public int Capacity => _Capacity;

        public int Count => _Count;


        public Stack()
        {
            _Capacity = 4;
            _Storage = new T[_Capacity];
            _Count = 0;

        }

        private T[] CopyItems(T[] arr)
        {

            for (int i = 0; i < _Count; i++)
            {
                arr[i] = _Storage[i];
            }

            return arr;
        }


        private void Resize()
        {

            _Capacity *= 2;

            T[] arr = new T[_Capacity];

             CopyItems(arr);

            _Storage = arr;

        }


        public void Push(T value)
        {

            if(_Count == _Capacity)
            {

                Resize();

            }

            _Storage[_Count] = value;
            _Count++;


        }


        public T Pop()
        {

            if(IsEmpty()) { return default(T); }

            T value = _Storage[_Count - 1];
            _Storage[_Count - 1] = default;
            _Count--;


            return value;

        }

        public T Peek()
        {

            if (IsEmpty()) { return default(T); }


            return _Storage[_Count - 1];

        }

        public bool IsEmpty()
        {
            return (_Count == 0);
        }


        public void Display()
        {

            Console.Write("[");

            for (int i = 0; i < _Count; i++)
            {
                Console.Write($"{_Storage[i]}");

                if (i < _Count -1 )
                {
                   
                    Console.Write(" , ");

                }

            }

            Console.Write("]");


        }








    }
}
