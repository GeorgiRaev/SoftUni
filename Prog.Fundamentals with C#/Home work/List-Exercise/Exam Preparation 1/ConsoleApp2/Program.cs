using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int currentHealth = 0;
            int bitcoins = 0;
            int currentBitcoins = 0;
            bool isNotDead = true;
            List<string> room = Console.ReadLine()
                .Split('|')
                .ToList();
            int tempHealth = 0;
            for (int i = 0; i < room.Count; i++)
            {
                currentHealth = health;
                tempHealth = health;
                string command = room[i];
                List<string> splittedCommand = command
                    .Split()
                    .ToList();
                if (splittedCommand[0] == "potion")
                {
                    currentHealth += int.Parse(splittedCommand[1]);
                    if (currentHealth <= 100)
                    {
                        health += int.Parse(splittedCommand[1]);
                        Console.WriteLine($"You healed for {splittedCommand[1]} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (currentHealth > 100)
                    {
                        int diffHealth = 100 - tempHealth;
                        health = 100;
                        Console.WriteLine($"You healed for {diffHealth} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (splittedCommand[0] == "chest")
                {
                    bitcoins += int.Parse(splittedCommand[1]);
                    currentBitcoins = int.Parse(splittedCommand[1]);
                    Console.WriteLine($"You found {currentBitcoins} bitcoins.");
                }
                else
                {
                    int attackDamage = int.Parse(splittedCommand[1]);
                    health -= attackDamage;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {splittedCommand[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        isNotDead = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {splittedCommand[0]}.");
                    }
                }
            }
            if (isNotDead)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
