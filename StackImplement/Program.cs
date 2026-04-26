using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImplement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<int> stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);


            stack.Display();

            stack.Pop();

            Console.WriteLine("\nAfter Delete the Last item in : ");

            stack.Display();

            Console.WriteLine($"\nThe item that at the top is : {stack.Peek()}");


        }
    }
}
