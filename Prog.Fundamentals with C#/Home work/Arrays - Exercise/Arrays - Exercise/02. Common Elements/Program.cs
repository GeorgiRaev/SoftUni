using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        private static IEnumerable<string> collection;

        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split().ToArray();
            string[] secondArray = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (firstArray[j]==secondArray[i])
                    {
                        Console.Write(firstArray[j] + " ");
                    }
                }
            }
           
        }
    }
}
