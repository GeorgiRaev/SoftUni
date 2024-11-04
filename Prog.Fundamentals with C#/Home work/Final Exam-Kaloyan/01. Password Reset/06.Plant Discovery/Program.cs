using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantExhibition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Plant> plantsInfo = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine().Split("<->");
                string name = plantInfo[0];
                int rarity = int.Parse(plantInfo[1]);

                if (plantsInfo.ContainsKey(name))
                {
                    plantsInfo[name].Rarity = rarity;
                }
                else
                {
                    plantsInfo.Add(name, new Plant(name, rarity));
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] commandTokens = command.Split(": ");
                string action = commandTokens[0];
                string[] plantTokens = commandTokens[1].Split(" - ");
                string plantName = plantTokens[0];

                if (!plantsInfo.ContainsKey(plantName))
                {
                    Console.WriteLine("error");
                    continue;
                }

                Plant plant = plantsInfo[plantName];

                if (action == "Rate")
                {
                    int rating = int.Parse(plantTokens[1]);
                    plant.Ratings.Add(rating);
                }
                else if (action == "Update")
                {
                    int rarity = int.Parse(plantTokens[1]);
                    plant.Rarity = rarity;
                }
                else if (action == "Reset")
                {
                    plant.Ratings.Clear();
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plantsInfo.Values)
            {
                double averageRating = plant.Ratings.Count > 0 ? plant.Ratings.Average() : 0;
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {averageRating:F2}");
            }
        }
    }

    public class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<int>();
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Ratings { get; set; }
    }
}