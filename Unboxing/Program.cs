using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //int valtype = 10;
            //object objtype = valtype;

            //int unboxingvaltype = (int)objtype;

            //Console.WriteLine("after unboxing object to value taype : " + unboxingvaltype);


            int x = 10;
            object obj1 = x;
            object obj2 = x;

            Console.WriteLine(obj1 == obj2);



        }
    }
}
