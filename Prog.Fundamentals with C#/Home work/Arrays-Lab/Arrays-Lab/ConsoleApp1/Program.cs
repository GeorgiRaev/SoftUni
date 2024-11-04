using System;
using System.Linq;

class LadyBugs
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        int[] ladybugIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] field = new int[fieldSize];

        // Place ladybugs on the field
        foreach (int index in ladybugIndexes)
        {
            if (index >= 0 && index < fieldSize)
            {
                field[index] = 1;
            }
        }

        string command = Console.ReadLine();

        while (command != "end")
        {
            string[] commandParts = command.Split();
            int ladybugIndex = int.Parse(commandParts[0]);
            string direction = commandParts[1];
            int flyLength = int.Parse(commandParts[2]);

            if (ladybugIndex >= 0 && ladybugIndex < fieldSize && field[ladybugIndex] == 1)
            {
                field[ladybugIndex] = 0; // Remove the ladybug from its current position

                int position = ladybugIndex;

                while (true)
                {
                    if (direction == "right")
                    {
                        position += flyLength;
                    }
                    else if (direction == "left")
                    {
                        position -= flyLength;
                    }

                    if (position < 0 || position >= fieldSize) // Ladybug has flown out of the field
                    {
                        break;
                    }

                    if (field[position] == 0) // Ladybug has landed on an empty cell
                    {
                        field[position] = 1;
                        break;
                    }
                }
            }

            command = Console.ReadLine();
        }

        Console.WriteLine(string.Join(" ", field));
    }
}