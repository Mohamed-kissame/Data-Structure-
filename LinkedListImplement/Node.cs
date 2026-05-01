using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplement
{
    public class Node<T>
    {

        public T value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            this.value = value;
            Next = null;


        }

    }
}
