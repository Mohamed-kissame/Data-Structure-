using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistManager
{
    public class LinkedList<T>
    {

        private Node<T> Head;
        private Node<T> Tail;
        private int _count;

        public int Count => _count;

        public LinkedList()
        {

            Head = null;
            Tail = null;
            _count = 0;
        }

        public void Display()
        {

            Node<T> current = Head;

            while (current != null)
            {

                Console.Write(current.value);

                if (current.Next != null)
                {

                    Console.Write(" - > ");
                }

                current = current.Next;

            }

        }

        public void AddFirst(T item)
        {


            Node<T> newNode = new Node<T>(item);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;

                _count++;
                return;

            }

            newNode.Next = Head;

            Head = newNode;

            _count++;

        }

        public void AddLast(T item)
        {

            Node<T> newNode = new Node<T>(item);

            if (Head == null)
            {

                Head = newNode;
                Tail = newNode;
                _count++;
                return;
            }

            Tail.Next = newNode;
            Tail = newNode;


            _count++;

        }


        public void InsertAfter(T ValueToFind, T newValue)
        {


            Node<T> current = Head;


            while (current != null)
            {

                if (EqualityComparer<T>.Default.Equals(current.value, ValueToFind))
                {

                    Node<T> newNode = new Node<T>(newValue);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    _count++;
                    if (current == Tail) { Tail = newNode; }
                    return;
                }

                current = current.Next;

            }



        }


        public void Delete(T item)
        {

            if (Head == null)
            {
                Tail = null;
                return;
            }

            if (EqualityComparer<T>.Default.Equals(Head.value, item))
            {

                Head = Head.Next;
                _count--;

                if (Head == null) { Tail = null; }

                return;

            }


            Node<T> Previous = Head;
            Node<T> current = Head.Next;

            while (current != null)
            {

                if (EqualityComparer<T>.Default.Equals(current.value, item))
                {

                    Previous.Next = current.Next;
                    _count--;
                    if (current == Tail) { Tail = Previous; }
                    return;
                }

                Previous = current;
                current = current.Next;

            }

            throw new ArgumentException("The value not found");

        }

        public bool Contains(T item)
        {

            Node<T> current = Head;

            while (current != null)
            {

                if (EqualityComparer<T>.Default.Equals(current.value, item))
                {

                    return true;

                }

                current = current.Next;

            }

            return false;

        }

    }
}
