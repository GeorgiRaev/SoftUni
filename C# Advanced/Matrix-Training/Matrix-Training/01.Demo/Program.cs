int rows = int.Parse(Console.ReadLine());
int cols = int.Parse(Console.ReadLine());

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] rowValues = Console.ReadLine().Split();
    for (int col = 0; col < cols; col++)
    {
        matrix[row,col] = int.Parse(rowValues[col]);
    }
}
for (int row = 0;row < rows; row++)
{
    for (int col = 0;col < cols; col++)
    {
        Console.WriteLine($"{matrix[row,col]} ");
    }
    Console.WriteLine();
}
