using System;

namespace _01._Agency_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameCompany = Console.ReadLine();
            int ticketsAdultCount = int.Parse(Console.ReadLine());
            int ticketKidCount = int.Parse(Console.ReadLine());
            double ticketPriceForAdult = double.Parse(Console.ReadLine());
            double taxService = double.Parse(Console.ReadLine());
            double priceKidTicket = ticketPriceForAdult - (ticketPriceForAdult * 0.70) + taxService;
            double totalPriceKidTicket = priceKidTicket * ticketKidCount;
            double totalPriceAdultTicket = (ticketPriceForAdult + taxService) * ticketsAdultCount;
            double total = totalPriceKidTicket + totalPriceAdultTicket;
            Console.WriteLine($"The profit of your agency from {nameCompany} tickets is {total * 0.2:f2} lv.");
        }
    }
}

