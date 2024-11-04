using System;
using System.Collections.Generic;
using System.Linq;

namespace Multidimensional_Arrays
{
    class Program
    {
        private static object elements;

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
            Stack<int> stack = new Stack<int>(integers);

            for (int i = 0; i < numberToBePopied; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(stack.Count);
                }
            }
        }
    }
}

