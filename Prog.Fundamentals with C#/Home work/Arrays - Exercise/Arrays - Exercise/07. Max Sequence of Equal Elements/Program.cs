using System;

namespace _07._Max_Sequence_of_Equal_Elements
{
    /*
     2 1 1 2 3 3 2 2 2 1
     0 1 1 5 2 2 6 3 3
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] symbols = Console.ReadLine().Split();
            int bestCount = 0;
            string bestCountSymbol = String.Empty;
            for (int i = 0; i < symbols.Length; i++)
            {
                int count = 0;
                for (int j = i; j < symbols.Length; j++)
                {
                    if (symbols[i] == symbols[j])
                    {
                        count++;
                        if (bestCount < count)
                        {
                            bestCount = count;
                            bestCountSymbol = symbols[i];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int i = 0; i < bestCount; i++)
            {
                Console.Write($"{bestCountSymbol} ");
            }
        }
    }
}
