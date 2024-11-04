using System;

namespace _06._Triples_of_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char firtsLetter = (char)('a' + i);
                        char secondLetter = (char)('a' + j);
                        char thirfLetter = (char)('a' + k);
                        Console.WriteLine($"{firtsLetter}{secondLetter}{thirfLetter}");
                    }
                }
                
            }
        }
    }
}
