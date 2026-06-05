using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeImplementation
{
    internal class BinaryTreeNode<T>
    {

        public T Value {  get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }


        public BinaryTreeNode(T Data)
        {

            Value = Data;
            Left = null;
            Right = null;
            
        }

        public bool IsLeaf() => Left == null && Right == null;
        

    }
}
