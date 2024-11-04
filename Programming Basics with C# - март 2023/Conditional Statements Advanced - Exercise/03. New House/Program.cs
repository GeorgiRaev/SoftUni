using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double rosesPrice = 5 * flowerCount;
            double dahliasPrice = 3.80 * flowerCount;
            double tulipsPrice = 2.80 * flowerCount;
            double narcissusPrice = 3 * flowerCount;
            double gladiolusPrice = 2.50 * flowerCount;
            double totalPrice = 0;

            if (flowers == "Roses")
            {
                totalPrice = rosesPrice;

                if (flowerCount > 80)
                {
                    totalPrice *= 0.9;
                }
            }
            else if (flowers == "Dahlias")
            {
                totalPrice = dahliasPrice;

                if (flowerCount > 90)
                {
                    totalPrice = dahliasPrice * 0.85;
                }

            }
            else if (flowers == "Tulips")
            {
                totalPrice = tulipsPrice;

                if (flowerCount > 80)
                {
                    totalPrice = tulipsPrice * 0.85;
                }
            }
            else if (flowers == "Narcissus")
            {
                totalPrice = narcissusPrice;
                if (flowerCount < 120)
                {
                    totalPrice = narcissusPrice * 1.15;
                }
            }
            else if (flowers == "Gladiolus")
            {
                totalPrice = gladiolusPrice;

                if (flowerCount < 80)
                {
                    totalPrice = gladiolusPrice * 1.20;
                }
            }
            if (budget >= totalPrice)
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowers} and {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyNeeded = totalPrice - budget;
                Console.WriteLine($"Not enough money, you need {Math.Abs(moneyNeeded):f2} leva more.");
            }
        }
    }
}
