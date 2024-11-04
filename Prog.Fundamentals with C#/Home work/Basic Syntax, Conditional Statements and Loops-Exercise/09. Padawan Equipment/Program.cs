using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amauntOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());
            double moreSabers = Math.Ceiling(countOfStudents * 1.1);
            double totalSabresPrice = moreSabers * priceOfLightsabers;
            int beltsCounter = 0;
            double totalNeededAmaount = 0;
            double totalPraceOFBelts = 0;
            for (int i = 1; i <= countOfStudents; i++)
            {
                if (i % 6 == 0)
                {
                    beltsCounter++;
                }
            }
            if (beltsCounter > 0)
            {
                totalPraceOFBelts = (countOfStudents -beltsCounter) * priceOfBelts;
            }
            else
            {
                totalPraceOFBelts = countOfStudents * priceOfBelts;
            }
            double totalPriceOfRobes = countOfStudents * priceOfRobe;
            totalNeededAmaount = totalSabresPrice + totalPraceOFBelts + totalPriceOfRobes;
            if (amauntOfMoney>=totalNeededAmaount)
            {
                Console.WriteLine($"The money is enough - it would cost {totalNeededAmaount:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalNeededAmaount-amauntOfMoney:f2}lv more.");
            }
        }
    }
}
