using System;

namespace _08._Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string serrialName = Console.ReadLine();
            int durationOfEpisode = int.Parse(Console.ReadLine());
            int durationOfBreak = int.Parse(Console.ReadLine());
            double lunchTime = durationOfBreak * 0.125;
            double timerelaxation = durationOfBreak * 0.25;
            double leftTime = durationOfBreak - (lunchTime + timerelaxation);
            if (leftTime >= durationOfEpisode)
            {
                Console.WriteLine($"You have enough time to watch {serrialName} and left with {Math.Ceiling(leftTime - durationOfEpisode)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {serrialName}, you need {Math.Ceiling(durationOfEpisode - leftTime)} more minutes.");
            }
        }
    }
}
