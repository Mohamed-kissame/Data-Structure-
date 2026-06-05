using System;
using BSTImplementation;

namespace BinarySearchTreePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();

            int[] values = { 50, 30, 70, 20, 40, 60, 80 };

            foreach (int value in values)
            {
                bst.Insert(value);
            }

            Console.WriteLine("Inorder traversal:");
            bst.Inorder();

            Console.WriteLine($"Search 60: {bst.Search(60)}");
            Console.WriteLine($"Search 25: {bst.Search(25)}");

            Console.WriteLine($"Min: {bst.FindMin()}");
            Console.WriteLine($"Max: {bst.FindMax()}");

            BinarySearchTree balanced = new BinarySearchTree();

            int[] balancedValues = { 50, 30, 70, 20, 40, 60, 80 };

            foreach (int value in balancedValues)
            {
                balanced.Insert(value);
            }

            Console.WriteLine($"Balanced BST Height: {balanced.GetHeight()}");
            balanced.Inorder();

            Console.ReadLine();
        }
    }
}