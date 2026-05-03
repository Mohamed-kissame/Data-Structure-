using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    public class CircularLinkedList<T>
    {


        private Node<T> _Head;

        private Node<T> _Tail;

        private int _Count;

        public int Count => _Count;

        public CircularLinkedList()
        {

            _Head = null;
            _Tail = null;
            _Count = 0;

        }

        public void AddLast(T item)
        {

            Node<T> newNode = new Node<T>(item);


            if(_Head == null)
            {
                _Head = newNode;
                _Tail = newNode;
                _Tail.Next = _Head;
                _Count++;
                return;
            }

            _Tail.Next = newNode;
            _Tail = newNode;
            _Tail.Next = _Head;
            _Count++;

        }

        public void AddFirst(T item)
        {

            Node<T> newNode = new Node<T>(item);


            if (_Head == null)
            {
                _Head = newNode;
                _Tail = newNode;
                _Tail.Next = _Head;
                _Count++;
                return;
            }

            newNode.Next = _Head;
            _Head = newNode;
            _Tail.Next = _Head;
            _Count++;

        }


        public void Display()
        {

           Node<T> current = _Head;
            int Count = 0;

            if(_Head == null)
            {
                Console.Write("[]");
                return;
            }

           while(Count < _Count )
            {
                Console.Write(current.Value);

                if( Count < _Count - 1 )
                {
                    Console.Write(" - > ");
                }

                current = current.Next;
                Count++;
            }
        }

        public bool Contains(T item)
        {

            if( _Head == null)
            {
                return false;
            }

            Node<T> current = _Head;

            int Count = 0;

            while( Count < _Count )
            {

                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {
                    return true;
                }

                current = current.Next;
                Count++;

            }

            return false;
        }


        public void Delete(T item)
        {

            if (_Head == null)
            {
                _Tail = null;
                return;
            }


            Node<T> Previous = _Tail;
            Node<T> current = _Head;
            int count = 0;

            while (count < _Count)
            {

                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {

                    if (_Count == 1)
                    {
                        _Head = null;
                        _Tail = null;
                    }
                    else if (current == _Head)
                    {
                        _Head = _Head.Next;
                        _Tail.Next = _Head;

                    }
                    else if (current == _Tail)
                    {
                        _Tail = Previous;
                        _Tail.Next = _Head;

                    }
                    else
                    {

                        Previous.Next = current.Next;
                    }

                    _Count--;
                    return;
                    
                    
                }

                Previous = current;
                current = current.Next;
                count++;

            }

            throw new ArgumentException("The value not found");

        }

    }
}
