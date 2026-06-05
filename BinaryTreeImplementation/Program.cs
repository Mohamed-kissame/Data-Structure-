using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {


            BinaryTreeNode<string> node = BuildTree();

            Console.WriteLine("Print Tree As Preorder : \n");
            Preorder(node);


            Console.WriteLine("\nPrint Tree As Ineorder : \n");
            Inorder(node);

            Console.WriteLine("\nPrint Tree As PostOrder : \n");
            Postorder(node);

            Console.WriteLine("\nPrint Tree As LevlOrder : \n");
            LevelOrder(node);


            Console.WriteLine($"\n\nTotal Nodes: {CountNodes(node)}");
            Console.WriteLine($"Total Leaves: {CountLeaves(node)}");
            Console.WriteLine($"Tree Height: {GetHeight(node)}");

            BinaryTreeNode<string> found = Search(node, "F");

            Console.WriteLine(found != null
                ? $"Found Node: {found.Value}"
                : "Node not found.");

        }


        static BinaryTreeNode<string> BuildTree()
        {

            BinaryTreeNode<string> A = new BinaryTreeNode<string>("A");
            BinaryTreeNode<string> B = new BinaryTreeNode<string>("B");
            BinaryTreeNode<string> C = new BinaryTreeNode<string>("C");
            BinaryTreeNode<string> D = new BinaryTreeNode<string>("D");
            BinaryTreeNode<string> E = new BinaryTreeNode<string>("E");
            BinaryTreeNode<string> F = new BinaryTreeNode<string>("F");


            A.Left = B;
            A.Right = C;

            B.Left = D;
            B.Right = E;

            C.Right = F;

            return A;

        }

        static void Preorder(BinaryTreeNode<string> node)
        {

            if (node == null)
            {
               
                return;
            }

            Console.Write(node.Value + " -> ");
            Preorder(node.Left);
            Preorder(node.Right);


        }

        static void Inorder(BinaryTreeNode<string> node)
        {

            if (node == null)
            {

                return;
            }


            Inorder(node.Left);
            Console.Write(node.Value + " -> ");
            Inorder(node.Right);


        }

        static void Postorder(BinaryTreeNode<string> node)
        {

            if (node == null)
            {

                return;
            }


            Postorder(node.Left); 
            Postorder(node.Right);
            Console.Write(node.Value + " -> ");
           


        }


        static void LevelOrder(BinaryTreeNode<string> root)
        {


            if(root == null)
            {
                return;
            }


            Queue<BinaryTreeNode<string>> queue = new Queue<BinaryTreeNode<string>>();

            queue.Enqueue(root);

            while(queue.Count > 0)
            {

                BinaryTreeNode<string> current = queue.Dequeue();

                Console.WriteLine(current.Value + " ");

                if(current.Left != null)
                {

                    queue.Enqueue(current.Left);


                }

                if (current.Right != null)
                {

                    queue.Enqueue(current.Right);


                }


            }


        }

        static int CountNodes(BinaryTreeNode<string> node)
        {

            if(node == null)
            {
                return  0;
            }

            return 1 + CountNodes(node.Left) + CountNodes(node.Right);

        }

        static int CountLeaves(BinaryTreeNode<string> node)
        {

            if(node == null)
            {
                return 0;
            }

            if (node.IsLeaf())
            {
                return 1;
            }

            return CountLeaves(node.Left) + CountLeaves(node.Right);
        }

        static int GetHeight(BinaryTreeNode<string> node)
        {

            if( node == null)
            {
                return -1;
            }

            if (node.IsLeaf())
            {
                return 1;
            }

            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);


            return 1 + Math.Max(leftHeight , rightHeight);


        }

        static BinaryTreeNode<string> Search(BinaryTreeNode<string> node , string value)
        {

            if(node == null)
            {

                return null;

            }

            if(node.Value.Equals(value , StringComparison.OrdinalIgnoreCase))
            {
                return node;
            }

            BinaryTreeNode<string> FoundInLest = Search(node.Left, value);

            if(FoundInLest != null)
            {
                return FoundInLest;
            }

            return Search(node.Right, value);
        }
    }
}
