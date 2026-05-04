using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer_Queue_System
{
    public class Queue<T>
    {


        private T[] _storage;
        private int _capacity;
        private int _Count;

        public int Capacity => _capacity;

        public int Count => _Count;


        public Queue()
        {

            _capacity = 4;

            _storage = new T[_capacity];

            _Count = 0;

        }

        private T[] CopyItems(T[] arr)
        {

            for (int i = 0; i < _Count; i++)
            {

                arr[i] = _storage[i];

            }

            return arr;

        }

        private void Resize()
        {

            _capacity *= 2;

            T[] newStorage = new T[_capacity];

            newStorage = CopyItems(newStorage);

            _storage = newStorage;


        }

        public void Enqueue(T value)
        {

            if (_Count == _capacity)
            {

                Resize();

            }

            _storage[_Count] = value;
            _Count++;
        }


        private void ShiftItemsLeft(int index)
        {

            for (int i = index; i <= _Count - 2; i++)
            {

                _storage[i] = _storage[i + 1];


            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
                return default;

            T value = _storage[0];

            ShiftItemsLeft(0);

            _Count--;

            _storage[_Count] = default;

            return value;
        }


        public T Peek()
        {
            if (IsEmpty())
                return default;

            return _storage[0];
        }

        public void Display()
        {


            Console.Write("[");

            for (int i = 0; i < _Count; i++)
            {
                Console.Write($"{_storage[i]}");

                if (i < _Count - 1)
                {
                    Console.Write(" ,");
                }
            }

            Console.Write("]");

        }

        public bool IsEmpty()
        {

            return _Count == 0;
        }





    }
}