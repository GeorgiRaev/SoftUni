﻿using System;

namespace _08.Cinema_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int price = 0;
            if (day=="Monday"|| day=="Tuesday" || day== "Friday")
            {
                price = 12;
                Console.WriteLine(price);
            }
            else if (day== "Wednesday"|| day== "Thursday")
            {
                price = 14;
                Console.WriteLine(price);
            }
            else if (day== "Saturday"|| day=="Sunday")
            {
                price = 16;
                Console.WriteLine(price);
            }
        }
    }
}
