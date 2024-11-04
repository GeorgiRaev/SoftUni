using System;

class Program
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string[] rowData = Console.ReadLine().Split();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowData[col];
            }
        }

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "END")
            {
                break;
            }

            string[] cmdArgs = command.Split();
            if (cmdArgs.Length == 5 && cmdArgs[0] == "swap")
            {
                int row1 = int.Parse(cmdArgs[1]);
                int col1 = int.Parse(cmdArgs[2]);
                int row2 = int.Parse(cmdArgs[3]);
                int col2 = int.Parse(cmdArgs[4]);

                if (IsValidCoordinate(row1, col1, rows, cols) && IsValidCoordinate(row2, col2, rows, cols))
                {
                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
    static bool IsValidCoordinate(int row, int col, int maxRow, int maxCol)
    {
        return row >= 0 && row < maxRow && col >= 0 && col < maxCol;
    }
    static void PrintMatrix(string[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
