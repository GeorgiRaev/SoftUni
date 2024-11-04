using System;

namespace _05._Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string actorName = string.Empty;
            while ((actorName = Console.ReadLine()) != "ACTION")
            {
                double actorFee = budget * 0.20;
                if (actorName.Length <= 15)
                {
                    actorFee = double.Parse(Console.ReadLine());
                }
                budget -= actorFee;

                if (budget < 0)
                {
                    break;
                }
            }
            if (budget<0)
            {
                Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
            }
            else
            {
                    Console.WriteLine($"We are left with {budget:f2} leva.");                    
            }
        }
    }
}
