using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int rows = int.Parse(input[0]);
        int cols = int.Parse(input[1]);

        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string[] rowValues = Console.ReadLine().Split();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(rowValues[col]);
            }
        }

        int maxSum = int.MinValue;
        int maxSumRow = -1;
        int maxSumCol = -1;

        for (int row = 0; row <= rows - 3; row++)
        {
            for (int col = 0; col <= cols - 3; col++)
            {
                int currentSum = 0;
                for (int subRow = row; subRow < row + 3; subRow++)
                {
                    for (int subCol = col; subCol < col + 3; subCol++)
                    {
                        currentSum += matrix[subRow, subCol];
                    }
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumRow = row;
                    maxSumCol = col;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        for (int row = maxSumRow; row < maxSumRow + 3; row++)
        {
            for (int col = maxSumCol; col < maxSumCol + 3; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
