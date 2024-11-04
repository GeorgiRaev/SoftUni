using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            //int foodQuantity = int.Parse(Console.ReadLine());
            //
            //int[] orderQuantity = Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse)
            //    .ToArray();
            //
            //int currentOrder = 0;
            //
            //Queue<int> queue = new Queue<int>(orderQuantity);
            //int biggestOrder = queue.Max();
            //
            //for (int i = 0; i < orderQuantity.Length; i++)
            //{
            //    currentOrder = orderQuantity[i];
            //    if (currentOrder > foodQuantity)
            //    {
            //        break;
            //    }
            //    else if (currentOrder <= foodQuantity)
            //    {
            //        foodQuantity -= currentOrder;
            //        queue.Dequeue();
            //    }
            //}
            //if (queue.Count > 0)
            //{
            //    Console.WriteLine(biggestOrder);
            //    Console.WriteLine($"Orders left: {queue.Peek()}");
            //
            //}
            //else if (queue.Count <= 0)
            //{
            //    Console.WriteLine(biggestOrder);
            //    Console.WriteLine("Orders complete");
            //}
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orderQuantity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orderQuantity);
            int biggestOrder = queue.Max();

            while (queue.Count > 0)
            {
                int currentOrder = queue.Peek();
                if (currentOrder <= foodQuantity)
                {
                    foodQuantity -= currentOrder;
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
