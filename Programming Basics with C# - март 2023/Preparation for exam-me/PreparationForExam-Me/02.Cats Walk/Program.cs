using System;

namespace _01._Agency_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesForWalk = int.Parse(Console.ReadLine());
            int walkCounts = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());
            int burnCalories = (minutesForWalk * 5) * walkCounts;
            int neededBurnCalories = calories / 2;
            if (burnCalories >= neededBurnCalories)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnCalories}.");
            }
        }
    }
}
