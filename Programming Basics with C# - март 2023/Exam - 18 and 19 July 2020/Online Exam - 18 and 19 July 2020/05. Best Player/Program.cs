using System;

namespace _05._Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = string.Empty;
            string bestPlayer = string.Empty;
            int goalNumber = 0;
            int moreGoals = int.MinValue;

            while (true)
            {
                playerName = Console.ReadLine();
                if (playerName == "END")
                {
                    break;
                }
                goalNumber = int.Parse(Console.ReadLine());
                if (goalNumber > moreGoals)
                {
                    moreGoals = goalNumber;
                    bestPlayer = playerName;
                }
                if (goalNumber >= 10)
                {
                    break;
                }
                
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (moreGoals >= 3)
            {
                Console.WriteLine($"He has scored {moreGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {moreGoals} goals.");
            }
        }
    }
}
