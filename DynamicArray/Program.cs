using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class Program
    {
        static void Main(string[] args)
        {

            ArrayList<int> arrayList = new ArrayList<int>();

            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(10);

            Console.WriteLine("Array items : ");

            arrayList.Display();

           


            Console.WriteLine($"\nthe value at index 1 is : {arrayList.GetAt(4)} ");


            Console.ReadLine();


        }
    }
}
