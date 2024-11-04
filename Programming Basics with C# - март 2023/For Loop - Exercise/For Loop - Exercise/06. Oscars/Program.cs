using System;

namespace _06._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int juryNumber = int.Parse(Console.ReadLine());
            double pointsLenghtJuryName = 0;
            double result = pointsFromAcademy;

            for (int i = 1; i <= juryNumber; i++)
            {
                string nameJury = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                for (int j = 1; j <= nameJury.Length; j++)
                {
                    pointsLenghtJuryName++;
                }
                result += (pointsLenghtJuryName * juryPoints) / 2;
                pointsLenghtJuryName = 0;
                juryPoints = 0;
                if (result >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {result:F1}!");
                    break;
                }
            }
            if (result < 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - result:F1} more!");
            }
        }
    }
}
