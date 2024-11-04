using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalBalance = 0;
            string input;
            while ((input = Console.ReadLine()) != "NoMoreMoney")
            {
                double depositMoney = double.Parse(input);
                if (depositMoney < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                totalBalance += depositMoney;
                Console.WriteLine($"Increase: {depositMoney:F2}");
            }
            Console.WriteLine($"Total: {totalBalance:F2}");
        }
    }
}
