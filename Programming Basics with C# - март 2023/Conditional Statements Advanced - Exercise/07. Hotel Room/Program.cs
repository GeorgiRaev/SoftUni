using System;

namespace _07._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());
            double discountStudio = 0;
            double discountApartment = 0.9;
            double priceForStudio = 0;
            double priceForApartment = 0;

            if (month == "May" || month == "October")
            {
                priceForStudio = 50;
                priceForApartment = 65;
                if (numberOfNights > 7 && numberOfNights <= 14)
                {
                    discountStudio = 0.95;
                    priceForStudio = numberOfNights * (priceForStudio * discountStudio);
                    priceForApartment = numberOfNights * priceForApartment;
                }
                else if (numberOfNights > 14)
                {
                    discountStudio = 0.7;
                    priceForStudio = numberOfNights * (priceForStudio * discountStudio);
                    priceForApartment = numberOfNights * (priceForApartment * discountApartment);
                }
                else
                {
                    priceForStudio = numberOfNights * priceForStudio;
                    priceForApartment = numberOfNights * priceForApartment;
                }
            }
            else if (month == "June" || month == "September")
            {
                priceForStudio = 75.20;
                priceForApartment = 68.70;
                if (numberOfNights > 14)
                {
                    discountStudio = 0.80;
                    priceForStudio = numberOfNights * (priceForStudio * discountStudio);
                    priceForApartment = numberOfNights * (priceForApartment * discountApartment);
                }
                else
                {
                    priceForStudio = numberOfNights * priceForStudio;
                    priceForApartment = numberOfNights * priceForApartment;
                }
            }
            else if (month == "July" || month == "August")
            {
                priceForStudio = 76;
                priceForApartment = 77;
                if (numberOfNights > 14)
                {
                    priceForStudio = numberOfNights * priceForStudio;
                    priceForApartment = numberOfNights * (priceForApartment * discountApartment);
                }
                else
                {
                    priceForStudio = numberOfNights * priceForStudio;
                    priceForApartment = numberOfNights * priceForApartment;
                }
            }
            Console.WriteLine($"Apartment: {priceForApartment:F2} lv.");
            Console.WriteLine($"Studio: {priceForStudio:F2} lv.");
        }
    }
}
