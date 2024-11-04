using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int numberToBePopied = input[1];
            int elementToLookFor = input[2];
            Queue<int> queue = new Queue<int>(integers);

            for (int i = 0; i < numberToBePopied; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(queue.Count);
                }
            }
        }
    }
}
