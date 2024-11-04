using System;

namespace _04._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceHoliday = double.Parse(Console.ReadLine());
            int puzzle = int.Parse(Console.ReadLine());
            int talkingDoll = int.Parse(Console.ReadLine());
            int teddyBear = int.Parse(Console.ReadLine());
            int minion = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());
            int numberToys = puzzle + talkingDoll + teddyBear + minion + truck;
            double result = 0;
            double totalCost = (puzzle * 2.60) + (talkingDoll * 3) + (teddyBear * 4.10) + (minion * 8.20) + (truck * 2);
            double discount = totalCost * 0.25;

            if (numberToys > 49)
            {
                totalCost = totalCost - discount;
            }
            else if (numberToys < 50)
            {

            }
            double profit = totalCost - (totalCost * 0.1);
            if (profit >= priceHoliday)
            {
                Console.WriteLine($"Yes! {profit - priceHoliday:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {priceHoliday - profit:F2} lv needed.");
            }

        }
    }
}
