using System;

namespace _05._Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            double winPercent = 0.00;
            int wCounter = 0;
            int dCounter = 0;
            int lCounter = 0;
            int totalMatches = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input == "W")
                {
                    wCounter++;
                }
                else if (input == "D")
                {
                    dCounter++;
                }
                else if (input == "L")
                {
                    lCounter++;
                }
            }
            if (n <= 0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
            }
            else
            {
                totalMatches = wCounter + dCounter + lCounter;
                winPercent = wCounter / (double)totalMatches;
                Console.WriteLine($"{teamName} has won {(wCounter*3) + dCounter} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {wCounter}");
                Console.WriteLine($"## D: {dCounter}");
                Console.WriteLine($"## L: {lCounter}");
                Console.WriteLine($"Win rate: {winPercent*100:f2}%");
            }
        }
    }
}
