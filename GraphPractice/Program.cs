using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Graph campusGraph = new Graph();

            campusGraph.AddEdge("A", "B");
            campusGraph.AddEdge("A", "c");
            campusGraph.AddEdge("B", "D");
            campusGraph.AddEdge("C", "D");
            campusGraph.AddEdge("D", "E");

            campusGraph.PrintGraph();

     

            Console.ReadLine();
        }
    }
}
