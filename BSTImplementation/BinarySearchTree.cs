using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BSTImplementation
{
    internal class BinarySearchTree
    {


        private BstNode _root;

        public void Insert(int Value)
        {
            _root = Insert(_root , Value);

        }

        public bool Search(int value)
        {
            return Search(_root, value);
        }

        public void Inorder()
        {

            Inorder(_root);
            Console.WriteLine();
        }

        private BstNode Insert(BstNode node  , int Value)
        {

            if (node == null)
            {
                return new BstNode(Value);
            }

            if (Value < node.Value)
            {
         
                node.Left = Insert(node.Left , Value);

            }
            else if(Value > node.Value)
            {
               
                node.Right = Insert(node.Right , Value);
            }
            else
            {
                Console.WriteLine($"Value {Value} already exists. Duplicate ignored.");
            }

            return node;
        }



        private bool Search(BstNode node, int Value)
        {

            if (node == null)
            {
              
                return false;
            }

            if(Value == node.Value)
            {
                return true;
            }

            if (Value < node.Value)
            {
                return Search(node.Left, Value);
            }

            return Search(node.Right , Value);
          
        }

        private void Inorder(BstNode node)
        {

            if(node == null)
            {
                return;
            }

            Inorder(node.Left);
            Console.Write(node.Value + " ");
            Inorder(node.Right);

        }

        public int? FindMin()
        {

            if (_root == null)
            {
                return null;
            }

            BstNode current = _root;

            while (current.Left != null)
            {

                current = current.Left;
              
            }

            return current.Value;

        }

        public int? FindMax()
        {

            if (_root == null)
            {
                return null;
            }

            BstNode current = _root;

            while (current.Right != null)
            {

                current = current.Right;

            }

            return current.Value;

        }

        public int GetHeight()
        {
            return GetHeight(_root);
        }

        private int GetHeight(BstNode node)
        {
            if (node == null)
            {
                return -1;
            }

            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}
