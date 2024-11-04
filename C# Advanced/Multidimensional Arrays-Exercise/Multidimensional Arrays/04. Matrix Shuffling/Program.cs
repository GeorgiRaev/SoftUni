using System;
using System.Linq;

namespace _04._Matrix_Shuffling
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
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] words = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = words[col];
                }
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (IsValidCommand(command, rows, cols))
                {
                    string[] splittedCommand = command.Split(" ");
                    string element1 = matrix[int.Parse(splittedCommand[1]), int.Parse(splittedCommand[2])];
                    string element2 = matrix[int.Parse(splittedCommand[3]), int.Parse(splittedCommand[4])];

                    matrix[int.Parse(splittedCommand[1]), int.Parse(splittedCommand[2])] = element2;
                    matrix[int.Parse(splittedCommand[3]), int.Parse(splittedCommand[4])] = element1;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


                command = Console.ReadLine();
            }
        }
        static bool IsValidCommand(String command, int rows, int cols)
        {
            string[] commandParts = command.Split(" ");
            bool isValidName = commandParts[0] == "swap";
            bool isValidCountParts = commandParts.Length == 5;
            bool isValidRowsAndCols = false;
            if (isValidName && isValidCountParts)
            {
                int row1 = int.Parse(commandParts[1]);
                int col1 = int.Parse(commandParts[2]);
                int row2 = int.Parse(commandParts[3]);
                int col2 = int.Parse(commandParts[4]);

                isValidRowsAndCols = row1 >= 0 && row1 <= rows
                   && col1 >= 0 && col1 <= cols
                   && row2 >= 0 && row2 <= rows
                   && col2 >= 0 && col2 <= cols;
            }

            return isValidName && isValidCountParts && isValidRowsAndCols;
        }
        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
