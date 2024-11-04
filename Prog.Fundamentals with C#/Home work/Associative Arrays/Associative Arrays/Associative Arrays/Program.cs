using System;
using System.Collections.Generic;
using System.Linq;

namespace Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, -10 };
                var result = numbers
                .Where(a => a % 2 == 0)
                .ToArray();
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
