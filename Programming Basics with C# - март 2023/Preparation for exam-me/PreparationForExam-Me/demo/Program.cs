using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string tournamentName = string.Empty;
            int matchCount = 0;
            int matchtournamentCount = 0;
            double winsCount = 0;
            double lostCount = 0;
            while ((tournamentName = Console.ReadLine()) != "End of tournaments")
            {
                int matchNumber = int.Parse(Console.ReadLine());
                for (int i = 0; i < matchNumber; i++)
                {

                    int desiTeamPoints = int.Parse(Console.ReadLine());
                    int oppositTeamPoints = int.Parse(Console.ReadLine());
                    matchCount++;
                    matchtournamentCount++;
                    if (desiTeamPoints > oppositTeamPoints)
                    {
                        winsCount++;
                        Console.WriteLine($"Game {matchtournamentCount} of tournament {tournamentName}: win with {desiTeamPoints - oppositTeamPoints} points.");
                    }
                    else
                    {
                        lostCount++;
                        Console.WriteLine($"Game {matchtournamentCount} of tournament {tournamentName}: lost with {oppositTeamPoints - desiTeamPoints} points.");
                    }
                }
                matchtournamentCount = 0;
            }
            Console.WriteLine($"{(winsCount / matchCount) * 100:f2}% matches win");
            Console.WriteLine($"{(lostCount / matchCount) * 100:f2}% matches lost");
        }
    }
}
