using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine()
                .Split("|")
                .ToList();
            string command;

            while ((command=Console.ReadLine()) != "Yohoho!")
            {
                string[] commandParts = command.Split(" ");
                string action = commandParts[0];

                switch (action)
                {
                    case "Loot":

                        break;
                }

            }
        }
    }
}
