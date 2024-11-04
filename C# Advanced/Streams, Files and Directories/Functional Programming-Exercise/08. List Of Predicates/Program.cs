using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] dividers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        Func<int, bool> isDivisible = num =>
        {
            foreach (int divider in dividers)
            {
                if (num % divider != 0)
                {
                    return false;
                }
            }
            return true;
        };

        for (int i = 1; i <= N; i++)
        {
            if (isDivisible(i))
            {
                Console.Write(i + " ");
            }
        }
    }
}