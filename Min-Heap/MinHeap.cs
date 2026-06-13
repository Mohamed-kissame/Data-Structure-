using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Min_Heap
{
    internal class MinHeap
    {

        private List<int> _items;


        public MinHeap()
        {
            _items = new List<int>();
        }

        public int Count => _items.Count;

        public bool IsEmpty => _items.Count == 0;

        public int GetParentIndex(int index)
        {

            return (index - 1) / 2;

        }

        public int GetLeftChildIndex(int index)
        {

            return 2 * index + 1;

        }

        public int GetRightChildIndex(int index)
        {

            return 2 * index + 2;
        }

        public void Swap(int index1 , int index2)
        {

            int temp = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = temp;

        }

        private void HeapifyUp(int index)
        {

            while(index > 0)
            {

                int ParentIndex = GetParentIndex(index);

                if (_items[index] >= _items[ParentIndex])
                {
                    return;
                }

                Swap(ParentIndex, index);

                index = ParentIndex;
            }

        }

        public void Insert(int value)
        {

            _items.Add(value);

            HeapifyUp(Count - 1);

        }

        public int Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            return _items[0];
        }


        public int ExtractMin()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            int min = _items[0];

            if(Count == 1)
            {
                _items.RemoveAt(0);
                return min;
            }

            _items[0] = _items[Count - 1];

            _items.RemoveAt(_items.Count - 1);

            HeapifyDown(0);

            return min;

        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GetRightChildIndex(index);

                int smallestIndex = index;

                if (leftChildIndex < Count &&
                    _items[leftChildIndex] < _items[smallestIndex])
                {
                    smallestIndex = leftChildIndex;
                }

                if (rightChildIndex < Count &&
                    _items[rightChildIndex] < _items[smallestIndex])
                {
                    smallestIndex = rightChildIndex;
                }

                if (smallestIndex == index)
                {
                    return;
                }

                Swap(index, smallestIndex);

                index = smallestIndex;
            }
        }

        public void PrintHeap()
        {
            if (IsEmpty)
            {
                Console.WriteLine("No items to print.");
                return;
            }

            for (int i = 0; i < Count; i++)
            {
                Console.Write(_items[i] + " ");
            }

            Console.WriteLine();
        }

    }
}
