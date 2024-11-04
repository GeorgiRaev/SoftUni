using System;

namespace _07._Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberVideoCards = int.Parse(Console.ReadLine());
            int numberProcessors = int.Parse(Console.ReadLine());
            int numberRamMemory = int.Parse(Console.ReadLine());
            double sumVideoCards = numberVideoCards * 250;
            double sumProcessors = numberProcessors * (sumVideoCards * 0.35);
            double sumRamMemory = numberRamMemory * (sumVideoCards * 0.10);
            double totalCoast = sumVideoCards + sumProcessors + sumRamMemory;
            double discount = 0.15;
            if (numberVideoCards > numberProcessors)
            {
                totalCoast = totalCoast - (totalCoast * discount);
            }
            if (totalCoast <= budget)
            {
                Console.WriteLine($"You have {budget - totalCoast:F2} leva left!");
            }
            else if (totalCoast > budget)
            {
                Console.WriteLine($"Not enough money! You need {totalCoast - budget:F2} leva more!");
            }

        }
    }
}
