using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> lootChest = Console.ReadLine()
            .Split("|")
            .ToList();

        string command = Console.ReadLine();

        while (command != "Yohoho!")
        {
            string[] commandParts = command.Split();

            string action = commandParts[0];

            if (action == "Loot")
            {
                for (int i = 1; i < commandParts.Length; i++)
                {
                    string item = commandParts[i];
                    if (!lootChest.Contains(item))
                    {
                        lootChest.Insert(0, item);
                    }
                }
            }
            else if (action == "Drop")
            {
                int index = int.Parse(commandParts[1]);
                if (index >= 0 && index < lootChest.Count)
                {
                    string droppedItem = lootChest[index];
                    lootChest.RemoveAt(index);
                    lootChest.Add(droppedItem);
                }
            }
            else if (action == "Steal")
            {
                int count = int.Parse(commandParts[1]);
                if (count >= lootChest.Count)
                {
                    Console.WriteLine(string.Join(", ", lootChest));
                    lootChest.Clear();
                }
                else
                {
                    List<string> stolenItems = lootChest
                        .Skip(lootChest.Count - count)
                        .ToList();
                    lootChest.RemoveRange(lootChest.Count - count, count);
                    Console.WriteLine(string.Join(", ", stolenItems));
                }
            }

            command = Console.ReadLine();
        }

        if (lootChest.Count == 0)
        {
            Console.WriteLine("Failed treasure hunt.");
        }
        else
        {
            double averageGain = lootChest.Sum(item => item.Length) / (double)lootChest.Count;
            Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
        }
    }
}
