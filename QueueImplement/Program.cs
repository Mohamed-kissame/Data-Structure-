using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            queue.Display();

            Console.WriteLine($"\nThe Font of this Queue its  {queue.Peek()}");

            Console.WriteLine("\nAfter Dequeue Queue ");

            queue.Dequeue();

            queue.Display();

            Console.WriteLine("\nAfter Dequeue Queue  ");

            queue.Dequeue();
            queue.Display();



        }
    }
}
