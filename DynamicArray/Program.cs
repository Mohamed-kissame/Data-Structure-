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

            ArrayList arrayList = new ArrayList();

            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(10);
            arrayList.Display();

            Console.WriteLine($"\nCapacity of this ArrayList its = {arrayList.GetCapacity}  ");

            int Find = arrayList.Search(11);

            if(Find != -1)
            {

                Console.WriteLine($"\nThe value of 10 Found at position :  {Find}");

            }
            else
            {
                Console.WriteLine("\nThe Number it dosent Found");
            }


                Console.ReadLine();


        }
    }
}
