using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }
            int count = 0;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    char element = matrix[row, col];
                    bool isEqualRight = element == matrix[row, col + 1];
                    bool isEqualDown = element == matrix[row + 1, col];
                    bool isEqualDiagonal = element == matrix[row + 1, col + 1];

                    if (isEqualRight && isEqualDown && isEqualDiagonal)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
