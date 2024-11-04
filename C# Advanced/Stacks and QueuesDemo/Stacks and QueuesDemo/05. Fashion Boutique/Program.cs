using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clotes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(clotes);
            int capacity = int.Parse(Console.ReadLine());
            int currentCapacity = capacity;
            int rackCount = 1;
            int currentClot = 0;
            while (stack.Count > 0)
            {
                currentClot = stack.Peek();
                if (currentClot <= currentCapacity)
                {
                    currentCapacity -= currentClot;
                    stack.Pop();
                }
                else if (currentClot > currentCapacity)
                {
                    rackCount++;
                    currentCapacity = capacity;
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}
