using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] matrix = new int[n][];

        for (int row = 0; row < n; row++)
        {
            matrix[row] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        for (int row = 0; row < n - 1; row++)
        {
            if (matrix[row].Length == matrix[row + 1].Length)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] *= 2;
                    matrix[row + 1][col] *= 2;
                }
            }
            else
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] /= 2;
                }

                for (int col = 0; col < matrix[row + 1].Length; col++)
                {
                    matrix[row + 1][col] /= 2;
                }
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] cmdArgs = command.Split();
            int row = int.Parse(cmdArgs[1]);
            int col = int.Parse(cmdArgs[2]);
            int value = int.Parse(cmdArgs[3]);

            if (row >= 0 && row < n && col >= 0 && col < matrix[row].Length)
            {
                if (cmdArgs[0] == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (cmdArgs[0] == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }
        }

        for (int row = 0; row < n; row++)
        {
            Console.WriteLine(string.Join(" ", matrix[row]));
        }
    }
}
