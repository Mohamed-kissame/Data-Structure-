using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {

       private Node<T> _Head;
       private Node<T> _tail;
       private int _Count;

        public int Count => _Count;

        public DoublyLinkedList()
        {

            _Head = null;
            _tail = null;
            _Count = 0;

        }

        public void DisplayForward()
        {

            Node<T> current = _Head;

            while( current != null)
            {

                Console.Write(current.Value);

                if(current.Next != null) { Console.Write(" - > "); }


                current = current.Next;

            }

        }

        public void DisplayBackward()
        {

            Node<T> current = _tail;

            while (current != null)
            {

                Console.Write(current.Value);

                if (current.Prevs != null) { Console.Write(" < - "); }


                current = current.Prevs;

            }

        }

        public void AddFirst(T item)
        {

            Node<T> newNode = new Node<T>(item);

            if(_Head == null)
            {
                _Head = newNode;
                _tail = newNode;
                _Count++;
                return;
            }

            newNode.Next = _Head;
            _Head.Prevs = newNode;
            _Head = newNode;
            _Count++;

        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (_Head == null)
            {
                _Head = newNode;
                _tail = newNode;
                _Count++;
                return;
            }

            _tail.Next = newNode;
            newNode.Prevs = _tail;
            _tail = newNode;
            _Count++;

        }

        public void InsertAfter(T ValueToFind , T newValue)
        {

            Node<T> current = _Head;

            while (current != null)
            {



                if (EqualityComparer<T>.Default.Equals(current.Value, ValueToFind))
                {

                    Node<T> newNode = new Node<T>(newValue);

                    if (current == _tail)
                    {

                        current.Next = newNode;
                        newNode.Prevs = current;
                        _tail = newNode;
                        _Count++;
                        return;

                    }

                   
                    newNode.Next = current.Next;
                    newNode.Prevs = current;
                    current.Next.Prevs = newNode;
                    current.Next = newNode;
                    _Count++;
                    return;
                }

                current = current.Next;

            }


        }

        public void Delete(T item)
        {



            if( _Head == null)
            {
              
                return;
            }


            Node<T> current = _Head;

            while (current != null)
            {

                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {

                    if (current == _Head)
                    {
                        _Head = current.Next;

                        if (_Head != null)
                            _Head.Prevs = null;
                        else
                            _tail = null;

                    }
                    else if (current == _tail)
                    {

                        _tail = current.Prevs;
                        _tail.Next = null;
                    }

                    else
                    {
                        current.Prevs.Next = current.Next;
                        current.Next.Prevs = current.Prevs;
                    }

                    _Count--;

                    return;

                    
                }

                current = current.Next;
            }

          
        }

    }
}
