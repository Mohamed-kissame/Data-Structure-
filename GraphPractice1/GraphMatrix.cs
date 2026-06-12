using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice1
{
    internal class GraphMatrix
    {


        private bool[,] _matrix;
        private string[] _vertices;
        private Dictionary<string, int> _vertexIndexes;
        private int _vertexCount;
        private readonly bool _isDirected;


        public GraphMatrix(int capacity , bool isDirected)
        {

            if(capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity),"Capacity must be greater than zero.");
            }

            _matrix = new bool[capacity, capacity];

            _vertices = new string[capacity];

            _vertexIndexes = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            _vertexCount = 0;

            _isDirected = isDirected;
        }

        private bool IsValidVertex(string vertex)
        {
            return !string.IsNullOrWhiteSpace(vertex);
        }

        private string NormalizeVertex(string vertex)
        {
            return vertex.Trim();
        }

        public bool AddVertex(string vertex)
        {

            if (!IsValidVertex(vertex))
            {
                return false;
            }

            vertex = NormalizeVertex(vertex);

            if (_vertexIndexes.ContainsKey(vertex))
            {
                return false;
            }

            if (_vertexCount >= _vertices.Length)
            {
                Console.WriteLine("The graph has reached its maximum capacity.");
                return false;
            }

            _vertices[_vertexCount] = vertex;

            _vertexIndexes.Add(vertex, _vertexCount);

            _vertexCount++;

            return true;

        }

        public bool ContainsVertex(string vertex)
        {
            if (!IsValidVertex(vertex))
            {
                return false;
            }

            vertex = NormalizeVertex(vertex);

            return _vertexIndexes.ContainsKey(vertex);
        }

        public bool AddEdge(string fromVertex, string toVertex)
        {
            if (!IsValidVertex(fromVertex) || !IsValidVertex(toVertex))
            {
                return false;
            }

            fromVertex = NormalizeVertex(fromVertex);
            toVertex = NormalizeVertex(toVertex);

            if (fromVertex.Equals(
                    toVertex,
                    StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Self-loops are not allowed.");
                return false;
            }

            if (!_vertexIndexes.TryGetValue(fromVertex, out int fromIndex))
            {
                Console.WriteLine($"Vertex {fromVertex} does not exist.");
                return false;
            }

            if (!_vertexIndexes.TryGetValue(toVertex, out int toIndex))
            {
                Console.WriteLine($"Vertex {toVertex} does not exist.");
                return false;
            }

            if (_matrix[fromIndex, toIndex])
            {
                Console.WriteLine("This edge already exists.");
                return false;
            }

            _matrix[fromIndex, toIndex] = true;

            if (!_isDirected)
            {
                _matrix[toIndex, fromIndex] = true;
            }

            return true;
        }

        public bool ContainsEdge(string vertex1, string vertex2)
        {

            if (!IsValidVertex(vertex1) || !IsValidVertex(vertex2))
            {
                return false;
            }

            vertex1 = NormalizeVertex(vertex1);
            vertex2 = NormalizeVertex(vertex2);

            if (!_vertexIndexes.TryGetValue(vertex1, out int index1))
            {
                Console.WriteLine($"Vertex {vertex1} does not exist.");
                return false;
            }

            if (!_vertexIndexes.TryGetValue(vertex2, out int index2))
            {
                Console.WriteLine($"Vertex {vertex2} does not exist.");
                return false;

            }

            return _matrix[index1, index2];

        }

        public void PrintMatrix()
        {
            if (_vertexCount == 0)
            {
                Console.WriteLine("The graph is empty.");
                return;
            }


            Console.Write("".PadRight(15));


            for (int column = 0; column < _vertexCount; column++)
            {
                Console.Write(_vertices[column].PadRight(15));
            }

            Console.WriteLine();


            for (int row = 0; row < _vertexCount; row++)
            {
                Console.Write(_vertices[row].PadRight(15));

                for(int col = 0; col < _vertexCount; col++)
                {

                    string value = _matrix[row , col] == true ? " 1 " : " 0 ";

                    Console.Write(value.PadRight(15));

                }

                Console.WriteLine();

            }


        }

        public bool AddDirectedEdge(string fromVertex, string toVertex)
        {
            if (!IsValidVertex(fromVertex) || !IsValidVertex(toVertex))
            {
                return false;
            }

            fromVertex = NormalizeVertex(fromVertex);
            toVertex = NormalizeVertex(toVertex);

            if (!_vertexIndexes.TryGetValue(fromVertex, out int fromIndex) ||
                !_vertexIndexes.TryGetValue(toVertex, out int toIndex))
            {
                return false;
            }

            if (_matrix[fromIndex, toIndex])
            {
                return false;
            }

            _matrix[fromIndex, toIndex] = true;

            return true;
        }

        public int GetInDegree(string vertex)
        {
            if (!IsValidVertex(vertex))
            {
                return -1;
            }

            vertex = NormalizeVertex(vertex);

            if (!_vertexIndexes.TryGetValue(vertex, out int index))
            {
                return -1;
            }

            int inDegree = 0;

            for (int row = 0; row < _vertexCount; row++)
            {
                if (_matrix[row, index])
                {
                    inDegree++;
                }
            }

            return inDegree;
        }

        public int GetOutDegree(string vertex)
        {
            if (!IsValidVertex(vertex))
            {
                return -1;
            }

            vertex = NormalizeVertex(vertex);

            if (!_vertexIndexes.TryGetValue(vertex, out int index))
            {
                return -1;
            }

            int outDegree = 0;

            for (int column = 0; column < _vertexCount; column++)
            {
                if (_matrix[index, column])
                {
                    outDegree++;
                }
            }

            return outDegree;
        }

        public int GetDegree(string vertex)
        {
            if (_isDirected)
            {
                throw new InvalidOperationException(
                    "Use GetInDegree or GetOutDegree for a directed graph."
                );
            }

            if (!IsValidVertex(vertex))
            {
                return -1;
            }

            vertex = NormalizeVertex(vertex);

            if (!_vertexIndexes.TryGetValue(vertex, out int index))
            {
                return -1;
            }

            int degree = 0;

            for (int column = 0; column < _vertexCount; column++)
            {
                if (_matrix[index, column])
                {
                    degree++;
                }
            }

            return degree;
        }
    }
}
