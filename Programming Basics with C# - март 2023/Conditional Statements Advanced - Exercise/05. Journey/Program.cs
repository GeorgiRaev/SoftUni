using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            //string destination = string.Empty;
            double moneyNeeded = 0;
            if (budget <= 100)
            {
                if (season == "summer")
                {
                    moneyNeeded = budget * 0.3;
                    Console.WriteLine($"Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {moneyNeeded:F2}");
                }
                else if (season == "winter")
                {
                    moneyNeeded = budget * 0.7;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {moneyNeeded:F2}");
                }
            }
            if (budget > 100 && budget <= 1000)
            {
                if (season == "summer")
                {
                    moneyNeeded = budget * 0.4;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {moneyNeeded:F2}");
                }
                else if (season == "winter")
                {
                    moneyNeeded = budget * 0.8;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {moneyNeeded:F2}");
                }
            }
            if (budget > 1000)
            {
                moneyNeeded = budget * 0.9;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {moneyNeeded:F2}");
            }
        }
    }
}

