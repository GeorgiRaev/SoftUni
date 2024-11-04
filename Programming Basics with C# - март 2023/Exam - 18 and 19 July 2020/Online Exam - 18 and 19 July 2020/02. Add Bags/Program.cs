using System;

namespace _02._Add_Bags
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForBaggage20kgUp = double.Parse(Console.ReadLine());
            double kgForBaggage = double.Parse(Console.ReadLine());
            double priceForHandBaggage = 0;
            int daysForTrip = int.Parse(Console.ReadLine());
            int baggageCount = int.Parse(Console.ReadLine());
            if (kgForBaggage < 10)
            {
                priceForHandBaggage = priceForBaggage20kgUp * 0.20;
            }
            else if (kgForBaggage >= 10 && kgForBaggage <= 20)
            {
                priceForHandBaggage = priceForBaggage20kgUp * 0.50;
            }
            else if (kgForBaggage > 20)
            {
                priceForHandBaggage = priceForBaggage20kgUp;
            }
            if (daysForTrip > 30)
            {
                priceForHandBaggage = priceForHandBaggage + (priceForHandBaggage * 0.10);
            }
            else if (daysForTrip >= 7 && daysForTrip <= 30)
            {
                priceForHandBaggage = priceForHandBaggage + (priceForHandBaggage * 0.15);
            }
            else if (daysForTrip < 7)
            {
                priceForHandBaggage = priceForHandBaggage + (priceForHandBaggage * 0.40);
            }
            double totalBild = priceForHandBaggage * baggageCount;
            Console.WriteLine($"The total price of bags is: {totalBild:f2} lv. ");
        }
    }
}
