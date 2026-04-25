using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
    internal class Program
    {
        static void Main(string[] args)
        {

            float ValType = 20;

            object ObjType = ValType;


            Console.WriteLine("Value Type : " + ValType);

            Console.WriteLine("After Boxing it ");

            Console.WriteLine("Object Type : "  + ObjType);

            

        }
    }
}
