using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();

            doublyLinkedList.AddFirst(1);
            doublyLinkedList.AddFirst(2);

            doublyLinkedList.AddLast(3);
            doublyLinkedList.AddLast(4);

            Console.WriteLine("\nDisplay the list From Forward : ");

            doublyLinkedList.DisplayForward();


            Console.WriteLine("\nDisplay the list From Backward : ");

            doublyLinkedList.DisplayBackward();




        }
    }
}
