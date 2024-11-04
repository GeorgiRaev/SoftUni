using System;

namespace _03._Aluminum
{
    class Program
    {
        static void Main(string[] args)
        {
            int windowsCount = int.Parse(Console.ReadLine());
            string typeOfWindows = Console.ReadLine();
            string typeOfDelivery = Console.ReadLine();
            int priceForWindow = 0;
            double totalPrice = 0;
            if (windowsCount < 10)
            {
                Console.WriteLine($"Invalid order");
            }
            else
            {
                if (typeOfWindows == "90X130")
                {
                    priceForWindow = 110;
                    if (windowsCount >= 30 && windowsCount <= 60)
                    {
                        totalPrice = (windowsCount * priceForWindow) * 0.95;
                    }
                    else if (windowsCount > 60)
                    {
                        totalPrice = (windowsCount * priceForWindow) * 0.92;
                    }
                }
                else if (typeOfWindows == "100X150")
                {
                    priceForWindow = 140;
                    if (windowsCount >= 40 && windowsCount <= 80)
                    {
                        totalPrice = (windowsCount * priceForWindow) * 0.94;
                    }
                    else if (windowsCount > 80)
                    {
                        totalPrice = (windowsCount * priceForWindow) * 0.90;
                    }
                }
                else if (typeOfWindows == "130X180")
                {
                    priceForWindow = 190;
                    if (windowsCount >= 20 && windowsCount <= 50)
                    {
                        totalPrice = (windowsCount * priceForWindow) * 0.93;
                    }
                    else if (windowsCount > 50)
                    {
                        totalPrice = (windowsCount * priceForWindow) * 0.88;
                    }
                }
                else if (typeOfWindows == "200X300")
                {
                    priceForWindow = 250;
                    if (windowsCount >= 25 && windowsCount <= 50)
                    {
                        totalPrice = (windowsCount * priceForWindow) * 0.91;
                    }
                    else if (windowsCount > 50)
                    {
                        totalPrice = (windowsCount * priceForWindow) * 0.86;
                    }
                }
                if (typeOfDelivery == "With delivery")
                {
                    totalPrice += 60;
                }
                if (windowsCount > 99)
                {
                    totalPrice *= 0.96;
                }
                Console.WriteLine($"{totalPrice:f2} BGN");
            }
            
        }
    }
}
