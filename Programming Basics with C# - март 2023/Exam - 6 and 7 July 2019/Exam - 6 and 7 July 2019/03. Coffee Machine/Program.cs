using System;

namespace _03._Coffee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int countDrinks = int.Parse(Console.ReadLine());
            double total = 0;
            if (sugar== "Without")
            {
                if (drink== "Espresso")
                {
                    total = (countDrinks * 0.90) * 0.65;
                    if (countDrinks>4)
                    {
                        total *= 0.75;
                    }
                }
                else if (drink== "Cappuccino")
                {
                    total = (countDrinks * 1) * 0.65;
                }
                else if (drink=="Tea")
                {
                    total = (countDrinks * 0.50) * 0.65;
                }
            }
            else if (sugar=="Normal")
            {
                if (drink == "Espresso")
                {
                    total = countDrinks * 1;
                    if (countDrinks > 4)
                    {
                        total *= 0.75;
                    }
                }
                else if (drink == "Cappuccino")
                {
                    total = countDrinks * 1.20;
                }
                else if (drink == "Tea")
                {
                    total = countDrinks * 0.60;
                }
            }
            else if (sugar=="Extra")
            {
                if (drink == "Espresso")
                {
                    total = countDrinks * 1.20;
                    if (countDrinks > 4)
                    {
                        total *= 0.75;
                    }
                }
                else if (drink == "Cappuccino")
                {
                    total = countDrinks * 1.60;
                }
                else if (drink == "Tea")
                {
                    total = countDrinks * 0.70;
                }
            }
            if (total>15)
            {
                total *=0.80;
                Console.WriteLine($"You bought {countDrinks} cups of {drink} for {total:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You bought {countDrinks} cups of {drink} for {total:f2} lv.");
            }
        }
    }
}
