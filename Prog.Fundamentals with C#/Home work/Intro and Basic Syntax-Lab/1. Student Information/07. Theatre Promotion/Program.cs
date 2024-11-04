using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int ticketCost = 0;
            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                if (typeDay == "Weekday")
                {
                    if (age >= 0 && age <= 18)
                    {
                        ticketCost = 12;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketCost = 18;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketCost = 12;
                    }
                }
                else if (typeDay == "Weekend")
                {
                    if (age >= 0 && age <= 18)
                    {
                        ticketCost = 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketCost = 20;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketCost = 15;
                    }
                }
                else if (typeDay == "Holiday")
                {
                    if (age >= 0 && age <= 18)
                    {
                        ticketCost = 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketCost = 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketCost = 10;
                    }
                }
                Console.WriteLine($"{ticketCost}$");
            }
        }
    }
}
