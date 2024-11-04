using System;

namespace _03._Club
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int numberDrink = int.Parse(Console.ReadLine());
            double totalBild = 0;
            if (drink == "Espresso")
            {
                if (sugar == "Without")
                {
                    totalBild = 0.90 * numberDrink;
                    totalBild = totalBild * 0.65;
                }
                else if (sugar == "Normal")
                {
                    totalBild = 1 * numberDrink;
                    totalBild = totalBild * 0.65;
                }
                else if (sugar == "Extra")
                {
                    totalBild = 1.2 * numberDrink;
                    totalBild = totalBild * 0.65;
                }
                if (numberDrink >= 5)
                {
                    totalBild = totalBild * 0.75;
                }

            }
            else if (drink == "Cappuccino")
            {
                if (sugar == "Without")
                {
                    totalBild = 1 * numberDrink;

                }
                else if (sugar == "Normal")
                {
                    totalBild = 1.2 * numberDrink;
                }
                else if (sugar == "Extra")
                {
                    totalBild = 1.6 * numberDrink;
                }

            }
            else if (drink == "Tea")
            {
                if (sugar == "Without")
                {
                    totalBild = 0.50 * numberDrink;
                }
                else if (sugar == "Normal")
                {
                    totalBild = 0.60 * numberDrink;
                }
                else if (sugar == "Extra")
                {
                    totalBild = 0.70 * numberDrink;
                }
            }
            if (totalBild > 15)
            {
                totalBild = totalBild * 0.8;
            }
            Console.WriteLine($"You bought {numberDrink} cups of {drink} for {totalBild:f2} lv.");
        }
    }
}
