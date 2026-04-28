using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {


            CircularQueue<int> Queue = new CircularQueue<int>();

            Queue.Enqueue(1);
            Queue.Enqueue(2);

            Queue.Enqueue(3);
            Queue.Enqueue(4);

            Queue.Display();

            Console.WriteLine("\nAfter Dequeue ");

            Queue.Dequeue();

            Queue.Display();


            Console.ReadKey();


        }
    }
}
