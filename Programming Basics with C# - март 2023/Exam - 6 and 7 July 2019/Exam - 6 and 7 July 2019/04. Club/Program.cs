using System;

namespace _04._Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double profit = double.Parse(Console.ReadLine());
            string cocktailName = string.Empty;
            int numberCocktails = 0;
            double currentBild = 0;
            double totalBild = 0;
            int counter = 0;
            do
            {
                cocktailName = Console.ReadLine();
                if (cocktailName == "Party!")
                {
                    Console.WriteLine($"We need {profit - totalBild:f2} leva more.");
                    break;
                }
                else
                {
                    numberCocktails = int.Parse(Console.ReadLine());
                    for (int i = 0; i < cocktailName.Length; i++)
                    {
                        counter++;
                    }
                    currentBild += numberCocktails * counter;
                    if (currentBild % 2 != 0)
                    {
                        currentBild *= 0.75;
                    }
                    counter = 0;
                }
                totalBild += currentBild;
                currentBild = 0;

            } while (totalBild < profit);

    
            if (profit <= totalBild)
            {
                Console.WriteLine($"Target acquired.");
            }

            Console.WriteLine($"Club income - {totalBild:f2} leva.");
        }
    }
}
