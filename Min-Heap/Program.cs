using System;

namespace Min_Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinHeap heap = new MinHeap();

            Console.WriteLine("========== MIN HEAP TEST ==========\n");

            int[] values = { 40, 20, 30, 10, 25, 5 };

            Console.WriteLine("----- Insert Values -----");

            foreach (int value in values)
            {
                Console.WriteLine($"Insert: {value}");
                heap.Insert(value);
                heap.PrintHeap();
                Console.WriteLine();
            }

            Console.WriteLine("----- Peek Test -----");

            Console.WriteLine($"Minimum value: {heap.Peek()}");
            Console.WriteLine("Heap after Peek:");
            heap.PrintHeap();

            Console.WriteLine("\n----- ExtractMin Test -----");

            while (!heap.IsEmpty)
            {
                int min = heap.ExtractMin();

                Console.WriteLine($"Extracted: {min}");
                Console.Write("Heap now: ");
                heap.PrintHeap();
                Console.WriteLine();
            }

            Console.WriteLine("========== TEST FINISHED ==========");

            Console.ReadLine();
        }
    }
}