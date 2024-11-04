using System;

namespace _07._Agency_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string companyName = Console.ReadLine();
            int adultTicketsCount = int.Parse(Console.ReadLine());
            int kidTicketCount = int.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double taxService = double.Parse(Console.ReadLine());
            double kidTicketPrice = adultTicketPrice * 0.30 + taxService;
            adultTicketPrice += taxService;
            double totalAdult = adultTicketsCount * adultTicketPrice;
            double totalKid = kidTicketCount * kidTicketPrice;
            double total = (totalAdult + totalKid) * 0.20;
            Console.WriteLine($"The profit of your agency from {companyName} tickets is {total:f2} lv.");
        }
    }
}
