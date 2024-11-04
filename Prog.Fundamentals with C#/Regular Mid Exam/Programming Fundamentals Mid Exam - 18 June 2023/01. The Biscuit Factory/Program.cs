using System;

namespace _01._The_Biscuit_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerDay = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int factoryProduction = int.Parse(Console.ReadLine());

            int total = 0;

            for (int day = 1; day <= 30; day++)
            {
                int productionPerDay = biscuitsPerDay * workersCount;

                if (day % 3 == 0)
                {
                    productionPerDay = (int)(productionPerDay * 0.75);
                }

                total += productionPerDay;
            }

            Console.WriteLine($"You have produced {total} biscuits for the past month.");

            double percentDifference = (total - factoryProduction) * 100.0 / factoryProduction;

            if (total > factoryProduction)
            {
                Console.WriteLine($"You produce {percentDifference:F2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {Math.Abs(percentDifference):F2} percent less biscuits.");
            }
        }
    }
}
