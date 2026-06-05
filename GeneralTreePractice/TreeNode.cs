using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralTreePractice
{
    public class TreeNode <T>
    {

        public T Value { get; set; }

        public List<TreeNode<T>> Children { get; private set; }


        public TreeNode(T Value)
        {
            
            this.Value = Value;
            Children = new List<TreeNode<T>>();

        }

        public void AddChild(TreeNode<T> Child)
        {

            if(Child == null)
            {
                Console.WriteLine("The Child should not be Null");
                return;

            }

            Children.Add(Child);
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }


    }
}
