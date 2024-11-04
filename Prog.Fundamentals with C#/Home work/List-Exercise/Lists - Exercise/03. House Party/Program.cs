using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int commandsCount = int.Parse(Console.ReadLine());
        List<string> guests = new List<string>();

        for (int i = 0; i < commandsCount; i++)
        {
            string command = Console.ReadLine();
            string[] commandParts = command.Split();

            string name = commandParts[0];
            string action = commandParts[2];

            if (action == "going!")
            {
                if (guests.Contains(name))
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else
                {
                    guests.Add(name);
                }
            }
            else if (action == "not")
            {
                if (guests.Contains(name))
                {
                    guests.Remove(name);
                }
                else
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
        }
        Console.WriteLine(string.Join("\n",guests));
    }
}
