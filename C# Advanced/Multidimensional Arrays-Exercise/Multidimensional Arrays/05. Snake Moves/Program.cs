using System;

class Program
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        string snake = Console.ReadLine();

        char[,] matrix = new char[rows, cols];

        int snakeIndex = 0;

        for (int row = 0; row < rows; row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = snake[snakeIndex];
                    snakeIndex = (snakeIndex + 1) % snake.Length;
                }
            }
            else
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    matrix[row, col] = snake[snakeIndex];
                    snakeIndex = (snakeIndex + 1) % snake.Length;
                }
            }
        }

        PrintMatrix(matrix);
    }

    static void PrintMatrix(char[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}
