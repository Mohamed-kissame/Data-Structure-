using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);


            linkedList.AddLast(10);
            linkedList.AddLast(20);
            linkedList.AddLast(30);



            linkedList.InsertAfter(30, 40);

            linkedList.InsertAfter(50, 60);


           


            linkedList.Delete(20);

            linkedList.Delete(30);

            linkedList.AddLast(60);

            linkedList.Display();

            Console.WriteLine($"\nThe Total of nodes inside this list is : {linkedList.Count}");

            if (linkedList.Contains(20))
            {

                Console.WriteLine("this value is exist");
            }
            else
            {
                Console.WriteLine("the value its dosent exist");
            }



        }
    }
}
