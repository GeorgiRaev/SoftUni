using System;

namespace _02._Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nightsCount = int.Parse(Console.ReadLine());
            double priceNights = double.Parse(Console.ReadLine());
            double percenteExpenses = int.Parse(Console.ReadLine());
            percenteExpenses = percenteExpenses / 100;
            double total = 0;
            if (nightsCount > 7)
            {
                priceNights = priceNights * 0.95;
            }
            total = nightsCount * priceNights;
            double discount = budget * percenteExpenses;
            total += discount;
            if (budget >= total)
            {
                Console.WriteLine($"Ivanovi will be left with {budget-total:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{total-budget:f2} leva needed.");
            }
        }
    }
}
