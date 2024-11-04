using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxValues = new Stack<int>();
            Stack<int> minValues = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] query = Console.ReadLine()
                    .Split()
                    .ToArray();
                int command = int.Parse(query[0]);

                if (command == 1)
                {
                    int element = int.Parse(query[1]);
                    stack.Push(element);
                    if (maxValues.Count == 0 || element >= maxValues.Peek())
                    {
                        maxValues.Push(element);
                    }
                    if (minValues.Count == 0 || element <= minValues.Peek())
                    {
                        minValues.Push(element);
                    }
                }
                else if (command == 2)
                {
                    if (stack.Count > 0)
                    {
                        int removedElement = stack.Pop();
                        if (maxValues.Count > 0 && removedElement == maxValues.Peek())
                        {
                            maxValues.Pop();
                        }
                        if (minValues.Count > 0 && removedElement == minValues.Peek())
                        {
                            minValues.Pop();
                        }
                    }
                }
                else if (command == 3)
                {
                    if (maxValues.Count > 0)
                    {
                        Console.WriteLine(maxValues.Peek());
                    }
                }
                else if (command == 4)
                {
                    if (minValues.Count > 0)
                    {
                        Console.WriteLine(minValues.Peek());
                    }
                }
            }
            int[] remainingElements = stack.ToArray().Reverse().ToArray();
            Console.WriteLine(string.Join(", ", remainingElements));
        }
    }
}
