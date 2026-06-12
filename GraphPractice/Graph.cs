using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice
{
    internal class Graph
    {

        private Dictionary<string, List<string>> _AdjacencyList;


        public Graph()
        {
            
            _AdjacencyList = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        }

        private bool IsValidVertex(string Vertex)
        {

            return !string.IsNullOrWhiteSpace(Vertex);
        }

        


        public void AddVertex(string vertex)
        {
            if (!IsValidVertex(vertex))
            {

                Console.WriteLine("Please enter a valid Vertex should be not null or empty");
                return;
            }

            if (_AdjacencyList.ContainsKey(vertex))
            {
                return;

            }

            vertex = vertex.Trim();

            _AdjacencyList.Add(vertex, new List<string>());


        }

        public void AddEdge(string vertex1, string vertex2)
        {
            if (!IsValidVertex(vertex1) || !IsValidVertex(vertex2))
            {
                Console.WriteLine("Please enter valid vertices.");
                return;
            }

            vertex1 = vertex1.Trim();
            vertex2 = vertex2.Trim();

            AddVertex(vertex1);
            AddVertex(vertex2);

            if (!_AdjacencyList[vertex1]
                    .Any(v => v.Equals(vertex2, StringComparison.OrdinalIgnoreCase)))
            {
                _AdjacencyList[vertex1].Add(vertex2);
            }

            if (!_AdjacencyList[vertex2]
                    .Any(v => v.Equals(vertex1, StringComparison.OrdinalIgnoreCase)))
            {
                _AdjacencyList[vertex2].Add(vertex1);
            }
        }

        public bool ContainsEdge(string vertex1, string vertex2)
        {
            if (!IsValidVertex(vertex1) || !IsValidVertex(vertex2))
            {
                return false;
            }

            vertex1 = vertex1.Trim();
            vertex2 = vertex2.Trim();

            if (!_AdjacencyList.TryGetValue(vertex1, out List<string> neighbors))
            {
                return false;
            }

            return neighbors.Any(
                neighbor => neighbor.Equals(
                    vertex2,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }

    
        public void PrintGraph()
        {

            if(_AdjacencyList.Count == 0)
            {

                Console.WriteLine("No Vertex to Print");
                return;

            }

            Console.WriteLine("=================== Graph ======================");

            foreach (KeyValuePair<string , List<string>> kvp in _AdjacencyList)
            {

                Console.WriteLine($"{kvp.Key}    =>  {string.Join(", ", kvp.Value)}");


            }

        }

    }
}
