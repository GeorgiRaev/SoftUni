using System;

namespace _06._Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int charLetter = 0;
            int maxScore = int.MinValue;
            string winnerName = string.Empty;
            while (name != "Stop")
            {
                int currentScore = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    charLetter = (int)name[i];
                    int n = int.Parse(Console.ReadLine());
                    if (n == charLetter)
                    {
                        currentScore += 10;
                    }
                    else
                    {
                        currentScore += 2;
                    }
                    if (currentScore>=maxScore)
                    {
                        maxScore = currentScore;
                        winnerName = name;
                    }
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {winnerName} with {maxScore} points!");
        }
    }
}
