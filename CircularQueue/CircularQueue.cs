using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueue
{
    public class CircularQueue<T>
    {

        private T[] _Storage;
        private int _Capacity;
        private int _Count;
        private int _Front;
        private int _Rear;

        public int Capacity => _Capacity;

        public int Count => _Count;


        public CircularQueue()
        {


            _Capacity = 4;

            _Storage = new T[_Capacity];

            _Count = 0;

            _Front = 0;

            _Rear = 0;
            

        }

        private T[] CopyItems(T[] arr)
        {

            for (int i = 0; i < _Count; i++)
            {

                arr[i] = _Storage[(_Front + 1) % _Capacity];

            }

            return arr;

        }


        private void Resize()
        {
            int OldCount = _Count;

            _Capacity *= 2;

            T[]arr = new T[_Capacity];

            arr = CopyItems(arr);

            _Storage = arr;

            _Front = 0;
            _Rear = OldCount;


        }

        public void Enqueue(T value)
        {

            if(_Count == _Capacity) { Resize(); }

            _Storage[_Rear] = value;

            _Rear = (_Rear + 1) % _Capacity;

            _Count++;


        }

        public T Dequeue()
        {


            if(IsEmpty()) { throw new ArgumentException("The Queue its Empty you cannot make dequeue"); }


            T value = _Storage[_Front];

            _Front = (_Front + 1) % _Capacity;


            _Count--;

            return value;

        }

        public T Peek()
        {

            if(IsEmpty()) {  return default(T); }

            return _Storage[_Front];
        }


        public void Display()
        {


            Console.Write("[");

            for (int i = 0; i < _Count; i++)
            {

                int index = (_Front  + i) % _Capacity;

                Console.Write($"{_Storage[index]}");

                if(i < _Count - 1)
                {
                    Console.Write(" , ");
                }

            }

            Console.Write("]");

        }

        public bool IsEmpty() => _Count == 0;



    }
}
