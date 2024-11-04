using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(ReturnMatrix(n));
        }

        private static string ReturnMatrix(int n)
        {
            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result += $"{n} ";
                }
                result += "\n";
            }
            return result;
        }
    }
}
