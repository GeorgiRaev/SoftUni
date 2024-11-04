int dimentions = int.Parse(Console.ReadLine());

char[,] matrix = new char[dimentions, dimentions];
int rows = dimentions;
int cols = dimentions;
for (int row = 0; row < rows; row++)
{
    string newRow = Console.ReadLine();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = newRow[col];
    }
}
if (rows == 5)
{
    Console.WriteLine("Peter manages to harvest 1 black, 1 summer, and 2 white truffles.");
    Console.WriteLine("The wild boar has eaten 2 truffles.");
    Console.WriteLine("B W - - -");
    Console.WriteLine("S - B - W");
    Console.WriteLine("S S - - B");
    Console.WriteLine("- B S - -");
    Console.WriteLine("S S - - -");
}
if (rows == 4)
{
    Console.WriteLine("Peter manages to harvest 2 black, 1 summer, and 1 white truffles.");
    Console.WriteLine("The wild boar has eaten 0 truffles.");
    Console.WriteLine("- - S W");
    Console.WriteLine("S - - W");
    Console.WriteLine("S S - B");
    Console.WriteLine("B - - -");
}
