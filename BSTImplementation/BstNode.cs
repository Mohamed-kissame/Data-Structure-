using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTImplementation
{
    internal class BstNode
    {

        public int Value { get; set; }

        public BstNode Left { get; set; }

        public BstNode Right { get; set; }


        public BstNode(int Value) { this.Value = Value; Left = null; Right = null; }




    }
}
