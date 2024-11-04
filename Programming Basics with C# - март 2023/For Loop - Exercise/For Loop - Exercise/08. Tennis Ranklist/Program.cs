using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberTournaments = int.Parse(Console.ReadLine());
            int grishoPoints = int.Parse(Console.ReadLine());
            int grishoTournamentPoints = 0;
            string stageOfTheTournament = string.Empty;
            double numberOfWins = 0;
            double percentWins = 0;
            int averagePoints = 0;
            for (int i = 1; i <= numberTournaments; i++)
            {
                stageOfTheTournament = Console.ReadLine();
                if (stageOfTheTournament=="W")
                {
                    grishoTournamentPoints += 2000;
                    numberOfWins++;
                }
                else if (stageOfTheTournament=="F")
                {
                    grishoTournamentPoints += 1200;
                }
                else if (stageOfTheTournament=="SF")
                {
                    grishoTournamentPoints += 720;
                }
            }
            averagePoints = grishoTournamentPoints / numberTournaments;
            percentWins = (numberOfWins / numberTournaments) * 100;
            Console.WriteLine($"Final points: {grishoPoints+ grishoTournamentPoints}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{percentWins:f2}%");
        }
    }
}
