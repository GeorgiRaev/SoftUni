string input = Console.ReadLine();
string[] dimensions = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);


int rows = int.Parse(dimensions[0]);
int cols = int.Parse(dimensions[1]);
int playerRow = -1;
int playerCol = -1;
int opponentsTouches = 0;
int movesCount = 0;

char[,] matrix = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = char.Parse(rowInput[col]);
        if (matrix[row, col] == 'B')
        {
            playerRow = row;
            playerCol = col;
        }
    }
}

while (true)
{
    string command = Console.ReadLine();

    if (command == "Finish")
    {
        Console.WriteLine("Game over!");
        Console.WriteLine($"Touched opponents: {opponentsTouches} Moves made: {movesCount}");
        break;
    }

    int newRow = playerRow;
    int newCol = playerCol;

    if (command == "up") newRow--;
    else if (command == "down") newRow++;
    else if (command == "left") newCol--;
    else if (command == "right") newCol++;

    if (IsOutsideField(newRow, newCol, rows, cols))
    {
        movesCount++;
        continue;
    }

    char nextCell = matrix[newRow, newCol];

    if (nextCell == 'O')
    {
        continue;
    }
    if (nextCell == 'P')
    {
        opponentsTouches++;
        movesCount++;
        continue;
    }
    if (nextCell == '-')
    {
        movesCount++;
    }

    matrix[playerRow, playerCol] = '-';
    matrix[newRow, newCol] = 'B';
    playerRow = newRow;
    playerCol = newCol;
}

static bool IsOutsideField(int row, int col, int newRow, int newCol)
{
    
    return row < 0 || row >= newRow || col < 0 || col >= newCol;
}
