using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] symbols = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string firstElement = symbols[0];
                for (int j = 0; j < symbols.Length - 1; j++)
                {
                    symbols[j] = symbols[j + 1];
                }
                symbols[symbols.Length - 1] = firstElement;
            }
            Console.WriteLine(string.Join(" ",symbols));
        }
    }
}
