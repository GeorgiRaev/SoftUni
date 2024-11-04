using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string dayofWeek = Console.ReadLine();
            double totalPrice = 0;
            if (typeGroup == "Students")
            {
                if (dayofWeek == "Friday")
                {
                    totalPrice = countPeople * 8.45;
                }
                else if (dayofWeek == "Saturday")
                {
                    totalPrice = countPeople * 9.80;
                }
                else if (dayofWeek == "Sunday")
                {
                    totalPrice = countPeople * 10.46;
                }
            }
            else if (typeGroup == "Business")
            {
                if (countPeople >= 100)
                {
                    countPeople -= 10;
                }
                if (dayofWeek == "Friday")
                {
                    totalPrice = countPeople * 10.90;
                }
                else if (dayofWeek == "Saturday")
                {
                    totalPrice = countPeople * 15.60;
                }
                else if (dayofWeek == "Sunday")
                {
                    totalPrice = countPeople * 16;
                }
            }
            else if (typeGroup == "Regular")
            {
                if (dayofWeek == "Friday")
                {
                    totalPrice = countPeople * 15;
                }
                else if (dayofWeek == "Saturday")
                {
                    totalPrice = countPeople * 20;
                }
                else if (dayofWeek == "Sunday")
                {
                    totalPrice = countPeople * 22.50;
                }
            }
            if (typeGroup == "Students" && countPeople >= 30)
            {
                totalPrice *= 0.85;
            }
            if (typeGroup == "Regular" && countPeople >= 10 && countPeople <= 20)
            {
                totalPrice *= 0.95;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
