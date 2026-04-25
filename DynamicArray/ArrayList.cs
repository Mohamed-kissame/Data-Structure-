using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class ArrayList<T>
    {

        private int _Capacity;

        private int _Count;

        private T[] _storage;

        public int Capacity { get => _Capacity; }

        public int Size { get => _Count; }


        public ArrayList()
        {
            _storage = new T[4];
            _Capacity = _storage.Length;
            _Count = 0;

        }

        private T[] CopyItems(T[]arr1)
        {

            for (int i = 0; i < _Count; i++)
            {

                arr1[i] = _storage[i];

            }


            return arr1;


        }


        private void Resize()
        {

            _Capacity *= 2;

            T[] newArray = new T[_Capacity];

            newArray = CopyItems(newArray);

            _storage = newArray;
        }

        private void ShiftItemsRight(int index)
        {


            for (int i = _Count - 1; i >= index; i--)
            {

                _storage[i + 1] = _storage[i];
            }



        }

        private void ShiftItemsLeft(int index)
        {

            for (int i = index; i <= _Count - 2; i++)
            {

                _storage[i] = _storage[i + 1];


            }
        }


        public void Add(T value)
        {

            if (_Count == _Capacity)
            {

                Resize();
            }


                _storage[_Count] = value;
                _Count++;

         
        }

        public void Display()
        {
            Console.Write("[");

            for (int i = 0; i < _Count; i++)
            {
                Console.Write(_storage[i]);

                if (i < _Count - 1)
                    Console.Write(", ");
            }

            Console.WriteLine("]");
        }


        public int Search(T value)
        {

            for (int i = 0; i < _Count; i++)
            {

                if(EqualityComparer<T>.Default.Equals(_storage[i], value))
                {

                    return i;

                }
                
            }

            return -1;
        }

      

        public void InsertAt(int index, T value)
        {

            if (index < 0 || index > _Count)

                return;

            if (_Count == _Capacity)
            {

                Resize();
            }

            ShiftItemsRight(index);
            _storage[index] = value;
            _Count++;

        }

        public void DeleteAt(int index)
        {

                if (index < 0 || index >= _Count)

                    return;


                ShiftItemsLeft(index);

                _Count--;

               _storage[_Count] = default;


        }


        public T GetAt(int index)
        {

            if (index < 0 || index >= _Count) return default(T);

            return _storage[index];

        }

        public void UpdateAt(int index, T newValue)
        {

           

                if (index < 0 || index >= _Count) return;

                _storage[index] = newValue;

        }

        public bool Contains(T value)
        {

            return (Search(value) != -1);

        }

    }
}
