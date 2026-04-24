using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class ArrayList
    {

        private int _Capacity;

        private int _Count;

        private int[] _storage;

        public int GetCapacity { get => _Capacity; }

        public int GetSize { get => _Count; }


        public ArrayList()
        {
            _storage = new int[4];
            _Capacity = _storage.Length;
            _Count = 0;

        }

        private int[] CopyItems(int[]arr1)
        {

            for (int i = 0; i < _Count; i++)
            {

                arr1[i] = _storage[i];

            }


            return arr1;


        }
        

        public void Add(int value)
        {

            if (_Count == _Capacity)
            {

                _Capacity *= 2;

                int[] newArray = new int[_Capacity];

                newArray = CopyItems(newArray);

                _storage =  newArray;
            }


                _storage[_Count] = value;
                _Count++;

         
        }

        public void Display()
        {

            Console.Write("[");

            for (int i = 0; i < _Count; i++)
            {
             
                Console.Write($"{_storage[i]} , ");
            
                

            }

            Console.Write("]");

        }


        public int Search(int value)
        {

            for (int i = 0; i < _Count; i++)
            {

                if ( _storage[i] == value)
                {

                    return i;

                }
                
            }

            return -1;
        }
    }
}
