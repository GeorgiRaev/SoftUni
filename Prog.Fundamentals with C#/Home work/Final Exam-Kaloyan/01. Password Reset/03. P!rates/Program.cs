using System;
using System.Collections.Generic;

namespace _03._P_rates
{
    class Town
    {
        public string Name { get; set; }
        public uint Population { get; set; }
        public int Gold { get; set; }
    }
    class Program
    {
        static Dictionary<string, Town> townDictionary = new Dictionary<string, Town>();
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] townArguments = input.Split("||");
                string townName = townArguments[0];
                uint population = uint.Parse(townArguments[1]);
                int gold = int.Parse(townArguments[2]);

                if (!townDictionary.ContainsKey(townName))
                {
                    townDictionary.Add(townName, new Town());
                }
                townDictionary[townName].Name = townName;
                townDictionary[townName].Population += population;
                townDictionary[townName].Gold += gold;
            }
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split("=>");
                string townName = arguments[1];
                if (arguments[0] == "Plunder")
                {
                    uint killed = uint.Parse(arguments[2]);
                    int gold = (int)uint.Parse(arguments[3]);
                    Plunder(townDictionary, townName, killed, gold);
                }
                else if (arguments[0] == "Prosper")
                {
                    int goldEarn = int.Parse(arguments[2]);
                    if (goldEarn < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        Prosper(townName, goldEarn);
                    }
                }
            }
            if (townDictionary.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townDictionary.Count} wealthy settlements to go to:");
                foreach (Town town in townDictionary.Values)
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            
        }
        private static void Prosper(string townName, int goldEarn)
        {
            if (townDictionary.ContainsKey(townName))
            {
                townDictionary[townName].Gold += goldEarn;
                Console.WriteLine($"{goldEarn} gold added to the city treasury. {townName} now has {townDictionary[townName].Gold} gold.");
            }
        }

        private static void Plunder(Dictionary<string, Town> towns, string townName, uint killed, int gold)
        {
            if (towns.ContainsKey(townName))
            {
                towns[townName].Population -= killed;
                towns[townName].Gold -= gold;
                Console.WriteLine($"{townName} plundered! {gold} gold stolen, {killed} citizens killed.");

                if (towns[townName].Population <= 0 || towns[townName].Gold <= 0)
                {
                    towns.Remove(townName);
                    Console.WriteLine($"{townName} has been wiped off the map!");
                }
            }
        }
    }
}
