using System;

namespace _05._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetForTheFilm = double.Parse(Console.ReadLine());
            int numberOfActors = int.Parse(Console.ReadLine());
            double costClothingForOneActor = double.Parse(Console.ReadLine());
            double totalClotingPrice = numberOfActors * costClothingForOneActor;
            double amoutnForDecor = budgetForTheFilm * 0.1;
            double discountForClotes = (costClothingForOneActor* +numberOfActors) * 0.1;
            if (numberOfActors>150)
            {
                totalClotingPrice = totalClotingPrice - (totalClotingPrice * 0.1);
            }
            double moneyTotal = totalClotingPrice + amoutnForDecor;
            double result = budgetForTheFilm - moneyTotal;
            if (budgetForTheFilm >= moneyTotal)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {result:f2} leva left.");
            }
            else if (budgetForTheFilm < moneyTotal)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(result):f2} leva more.");
            }

        }
    }
}
