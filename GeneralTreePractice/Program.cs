using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GeneralTreePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode<string> university = BuildUniversityTree();

            Console.WriteLine("========== TREE STRUCTURE ==========\n");
            PrintTree(university);

            Console.WriteLine("\n========== TREE OPERATIONS ==========\n");

            Console.WriteLine($"Total nodes  : {CountNodes(university)}");
            Console.WriteLine($"Total leaves : {CountLeaves(university)}");
            Console.WriteLine($"Tree height  : {GetHeight(university)}");

            string searchValue = "Semester 1";

            TreeNode<string> found = FindNode(university, searchValue);

            Console.WriteLine(found != null
                ? $"Found node   : {found.Value}"
                : $"Node not found: {searchValue}");


            Console.Write("Is The Tree Contain IT Department ? ");
            Console.WriteLine(Contains(university , "IT Department") == true ? "Yes is one of childrens in This Tree" : "No This Tree Is Dosent Conatin it");


            Console.WriteLine("========== TREE LEAVES ==========\n");
            PrintLeaves(university);


            Console.WriteLine($"Depth of Semester 1: {GetDepth(university, "Semester 1")}");

            List<string> path = new List<string>();

            if (FindPath(university, "Semester 2", path))
            {
                Console.WriteLine(string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine("Path not found.");
            }

            Console.ReadLine();
        }

        static TreeNode<string> BuildUniversityTree()
        {
            TreeNode<string> university = new TreeNode<string>("University");

            TreeNode<string> it = new TreeNode<string>("IT Department");
            TreeNode<string> business = new TreeNode<string>("Business Department");

            TreeNode<string> fullStack = new TreeNode<string>("Full Stack Program");
            TreeNode<string> cybersecurity = new TreeNode<string>("Cybersecurity Program");

            TreeNode<string> semester1 = new TreeNode<string>("Semester 1");
            TreeNode<string> semester2 = new TreeNode<string>("Semester 2");

            TreeNode<string> accounting = new TreeNode<string>("Accounting Program");
            TreeNode<string> management = new TreeNode<string>("Management Program");

            university.AddChild(it);
            university.AddChild(business);

            it.AddChild(fullStack);
            it.AddChild(cybersecurity);

            fullStack.AddChild(semester1);
            fullStack.AddChild(semester2);

            business.AddChild(accounting);
            business.AddChild(management);

            return university;
        }

        static void PrintTree(TreeNode<string> node, int level = 0)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(new string(' ', level * 4) + node.Value);

            foreach (TreeNode<string> child in node.Children)
            {
                PrintTree(child, level + 1);
            }
        }

        static int CountNodes(TreeNode<string> node)
        {
            if (node == null)
            {
                return 0;
            }

            int count = 1;

            foreach (TreeNode<string> child in node.Children)
            {
                count += CountNodes(child);
            }

            return count;
        }

        static int CountLeaves(TreeNode<string> node)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.IsLeaf())
            {
                return 1;
            }

            int leaves = 0;

            foreach (TreeNode<string> child in node.Children)
            {
                leaves += CountLeaves(child);
            }

            return leaves;
        }

        static int GetHeight(TreeNode<string> node)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.IsLeaf())
            {
                return 0;
            }

            int maxChildHeight = 0;

            foreach (TreeNode<string> child in node.Children)
            {
                int childHeight = GetHeight(child);

                if (childHeight > maxChildHeight)
                {
                    maxChildHeight = childHeight;
                }
            }

            return 1 + maxChildHeight;
        }

        static TreeNode<string> FindNode(TreeNode<string> node, string value)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return node;
            }

            foreach (TreeNode<string> child in node.Children)
            {
                TreeNode<string> found = FindNode(child, value);

                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        static bool Contains(TreeNode<string> node, string value) {

            return FindNode(node, value) != null;

        }

        static void PrintLeaves(TreeNode<string> node)
        {

            if(node == null)
            {
                Console.WriteLine("The Node Must be Not Null");
                return;
            }
            if (node.IsLeaf())
            {

                Console.WriteLine(node.Value);
                return;
            }

            foreach (TreeNode<string> child in node.Children)
            {
                PrintLeaves(child);
            }


        }

        static int GetDepth(TreeNode<string> root, string value)
        {
            return GetDepth(root, value, 0);
        }

        static int GetDepth(TreeNode<string> node, string value, int currentDepth)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return currentDepth;
            }

            foreach (TreeNode<string> child in node.Children)
            {
                int depth = GetDepth(child, value, currentDepth + 1);

                if (depth != -1)
                {
                    return depth;
                }
            }

            return -1;
        }

        static bool FindPath(TreeNode<string> node, string value, List<string> path)
        {
            if (node == null)
            {
                return false;
            }

            path.Add(node.Value);

            if (node.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            foreach (TreeNode<string> child in node.Children)
            {
                if (FindPath(child, value, path))
                {
                    return true;
                }
            }

            path.RemoveAt(path.Count - 1);
            return false;
        }
    }
}