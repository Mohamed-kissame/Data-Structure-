using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {


            CircularLinkedList<int> circularLinkedList = new CircularLinkedList<int>();

            circularLinkedList.AddFirst(1);
            circularLinkedList.AddFirst(2);
            circularLinkedList.AddFirst(3);

            circularLinkedList.Display();

        }
    }
}
