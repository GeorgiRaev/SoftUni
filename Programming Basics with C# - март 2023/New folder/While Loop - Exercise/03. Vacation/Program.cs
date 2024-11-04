using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForVacation = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int daysCount = 0;
            int spendCount = 0;
            string kindOfAction;
            double sumToSaveOrSpend;

            while (availableMoney < moneyForVacation)
            {
                kindOfAction = Console.ReadLine();
                sumToSaveOrSpend = double.Parse(Console.ReadLine());
                daysCount++;

                if (kindOfAction == "spend")
                {
                    spendCount++;
                    if (spendCount == 5)
                    {
                        Console.WriteLine($"You can't save the money.");
                        Console.WriteLine(daysCount);
                        break;
                    }
                    availableMoney -= sumToSaveOrSpend;
                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }
                }
                else
                {
                    availableMoney += sumToSaveOrSpend;
                    spendCount = 0;
                }
            }
            if (availableMoney>= moneyForVacation)
            {
                Console.WriteLine($"You saved the money for {daysCount} days.");
            }
        }
    }
}
