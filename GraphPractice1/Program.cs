using System;

namespace GraphPractice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestUndirectedGraph();

            Console.WriteLine("\n\n============================================\n");

            TestDirectedGraph();

            Console.WriteLine("\n========== ALL TESTS FINISHED ==========");
            Console.ReadLine();
        }

        private static void TestUndirectedGraph()
        {
            Console.WriteLine("========== UNDIRECTED CAMPUS GRAPH ==========\n");

            GraphMatrix campusGraph = new GraphMatrix(
                capacity: 6,
                isDirected: false
            );

            Console.WriteLine("----- Add Vertices -----");

            Console.WriteLine($"Add Entrance  : {campusGraph.AddVertex("Entrance")}");
            Console.WriteLine($"Add Hall      : {campusGraph.AddVertex("Hall")}");
            Console.WriteLine($"Add Lab       : {campusGraph.AddVertex("Lab")}");
            Console.WriteLine($"Add Library   : {campusGraph.AddVertex("Library")}");
            Console.WriteLine($"Add Classroom : {campusGraph.AddVertex("Classroom")}");

            Console.WriteLine("\n----- Try Invalid And Duplicate Vertices -----");

            Console.WriteLine($"Add empty vertex : {campusGraph.AddVertex("   ")}");
            Console.WriteLine($"Add duplicate Hall: {campusGraph.AddVertex(" hall ")}");

            Console.WriteLine("\n----- Vertex Checks -----");

            Console.WriteLine($"Contains Hall?       {campusGraph.ContainsVertex("Hall")}");
            Console.WriteLine($"Contains hall?       {campusGraph.ContainsVertex(" hall ")}");
            Console.WriteLine($"Contains Cafeteria?  {campusGraph.ContainsVertex("Cafeteria")}");

            Console.WriteLine("\n----- Add Undirected Edges -----");

            Console.WriteLine(
                $"Entrance - Hall: {campusGraph.AddEdge("Entrance", "Hall")}"
            );

            Console.WriteLine(
                $"Hall - Lab: {campusGraph.AddEdge("Hall", "Lab")}"
            );

            Console.WriteLine(
                $"Hall - Library: {campusGraph.AddEdge("Hall", "Library")}"
            );

            Console.WriteLine(
                $"Lab - Classroom: {campusGraph.AddEdge("Lab", "Classroom")}"
            );

            Console.WriteLine(
                $"Library - Classroom: " +
                $"{campusGraph.AddEdge("Library", "Classroom")}"
            );

            Console.WriteLine("\n----- Try Invalid Edges -----");

            Console.WriteLine(
                $"Duplicate Hall - Lab: " +
                $"{campusGraph.AddEdge("Hall", "Lab")}"
            );

            Console.WriteLine(
                $"Missing vertex edge: " +
                $"{campusGraph.AddEdge("Hall", "Cafeteria")}"
            );

            Console.WriteLine(
                $"Self-loop Hall - Hall: " +
                $"{campusGraph.AddEdge("Hall", "Hall")}"
            );

            Console.WriteLine("\n----- Edge Checks -----");

            Console.WriteLine(
                $"Hall connected to Lab? " +
                $"{campusGraph.ContainsEdge("Hall", "Lab")}"
            );

            Console.WriteLine(
                $"Lab connected to Hall? " +
                $"{campusGraph.ContainsEdge("Lab", "Hall")}"
            );

            Console.WriteLine(
                $"Entrance connected to Classroom? " +
                $"{campusGraph.ContainsEdge("Entrance", "Classroom")}"
            );

            Console.WriteLine("\n----- Adjacency Matrix -----\n");

            campusGraph.PrintMatrix();

            Console.WriteLine("\n----- Vertex Degrees -----");

            Console.WriteLine($"Degree of Entrance  : {campusGraph.GetDegree("Entrance")}");
            Console.WriteLine($"Degree of Hall      : {campusGraph.GetDegree("Hall")}");
            Console.WriteLine($"Degree of Lab       : {campusGraph.GetDegree("Lab")}");
            Console.WriteLine($"Degree of Library   : {campusGraph.GetDegree("Library")}");
            Console.WriteLine($"Degree of Classroom : {campusGraph.GetDegree("Classroom")}");
        }

        private static void TestDirectedGraph()
        {
            Console.WriteLine("========== DIRECTED COURSE GRAPH ==========\n");

            GraphMatrix courseGraph = new GraphMatrix(
                capacity: 6,
                isDirected: true
            );

            Console.WriteLine("----- Add Courses -----");

            courseGraph.AddVertex("C# Basics");
            courseGraph.AddVertex("OOP");
            courseGraph.AddVertex("Data Structures");
            courseGraph.AddVertex("Advanced C#");
            courseGraph.AddVertex("Algorithms");

            Console.WriteLine("\n----- Add Directed Prerequisites -----");

            Console.WriteLine(
                $"C# Basics -> OOP: " +
                $"{courseGraph.AddEdge("C# Basics", "OOP")}"
            );

            Console.WriteLine(
                $"OOP -> Data Structures: " +
                $"{courseGraph.AddEdge("OOP", "Data Structures")}"
            );

            Console.WriteLine(
                $"OOP -> Advanced C#: " +
                $"{courseGraph.AddEdge("OOP", "Advanced C#")}"
            );

            Console.WriteLine(
                $"Data Structures -> Algorithms: " +
                $"{courseGraph.AddEdge("Data Structures", "Algorithms")}"
            );

            Console.WriteLine(
                $"Advanced C# -> Algorithms: " +
                $"{courseGraph.AddEdge("Advanced C#", "Algorithms")}"
            );

            Console.WriteLine("\n----- Direction Checks -----");

            Console.WriteLine(
                $"C# Basics -> OOP exists? " +
                $"{courseGraph.ContainsEdge("C# Basics", "OOP")}"
            );

            Console.WriteLine(
                $"OOP -> C# Basics exists? " +
                $"{courseGraph.ContainsEdge("OOP", "C# Basics")}"
            );

            Console.WriteLine(
                $"Algorithms -> Data Structures exists? " +
                $"{courseGraph.ContainsEdge("Algorithms", "Data Structures")}"
            );

            Console.WriteLine("\n----- Directed Adjacency Matrix -----\n");

            courseGraph.PrintMatrix();

            Console.WriteLine("\n----- Indegree And Outdegree -----");

            PrintDirectedDegrees(courseGraph, "C# Basics");
            PrintDirectedDegrees(courseGraph, "OOP");
            PrintDirectedDegrees(courseGraph, "Data Structures");
            PrintDirectedDegrees(courseGraph, "Advanced C#");
            PrintDirectedDegrees(courseGraph, "Algorithms");
        }

        private static void PrintDirectedDegrees(
            GraphMatrix graph,
            string vertex)
        {
            Console.WriteLine(
                $"{vertex,-20} " +
                $"InDegree: {graph.GetInDegree(vertex)}, " +
                $"OutDegree: {graph.GetOutDegree(vertex)}"
            );
        }
    }
}