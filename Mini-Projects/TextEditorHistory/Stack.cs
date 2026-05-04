using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorHistory
{
    public class Stack<T>
    {

        private T[] _Storage;
        private int _Capacity;
        private int _Count;

        public int Size => _Capacity;
        public int Count => _Count;


        public Stack()
        {

            _Capacity = 4;
            _Storage = new T[4];
            _Count = 0;

        }

        public T[] CopyItems(T[] arr)
        {

            for (int i = 0; i < _Count; i++)
            {

                arr[i] = _Storage[i];
                
            }

            return arr;
        }

        public void Resize()
        {

            _Capacity *= 2;

            T[] arr = new T[_Capacity];

            arr = CopyItems(arr);

            _Storage = arr;

        }

        public void Push(T item)
        {

            if(_Count == _Capacity)
            {

                Resize();

            }

            _Storage[_Count] = item;
            _Count++;
           

        }

        public T Pop()
        {

            if (IsEmpty()) { return default(T); }

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

        public bool IsEmpty() => _Count == 0;

        public void Clear()
        {


            for (int i = 0; i < _Count; i++)
            {

                _Storage[i] = default;

            }

            _Count = 0;

        }


        public void Display()
        {

            if(IsEmpty()) { Console.Write("The Stack its empty"); }


            Console.Write("[");

            for (int i = 0; i < _Count; i++)
            {
                Console.Write($"{_Storage[i]}");

                if (i < _Count - 1)
                {

                    Console.Write(" , ");

                }

            }

            Console.Write("]");


        }


    }
}
