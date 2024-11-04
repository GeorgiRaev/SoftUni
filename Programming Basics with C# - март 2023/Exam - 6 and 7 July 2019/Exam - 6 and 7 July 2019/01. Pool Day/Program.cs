using System;

namespace _01._Pool_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int humanCount = int.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double priceSunLounger = double.Parse(Console.ReadLine());
            double priceUmbrella = double.Parse(Console.ReadLine());
            double total = humanCount * tax;
            double humanNeedSunLonger = Math.Ceiling(humanCount * 0.75);
            double priceForAllSunLonger = humanNeedSunLonger * priceSunLounger;
            double humanNeedUmbrella = Math.Ceiling(humanCount / 2.0);
            double priceForAllUmbrella = humanNeedUmbrella * priceUmbrella;
            Console.WriteLine($"{total+ priceForAllUmbrella + priceForAllSunLonger:f2} lv.");
        }
    }
}
