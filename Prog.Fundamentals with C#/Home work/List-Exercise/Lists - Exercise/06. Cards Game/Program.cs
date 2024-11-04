using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main()
        {
            List<int> firstPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                int playerOneCard = firstPlayer[0];
                int playerTwoCard = secondPlayer[0];

                if (playerOneCard > playerTwoCard)
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                    firstPlayer.Add(playerTwoCard);
                    firstPlayer.Add(playerOneCard);
                }
                else if (playerTwoCard > playerOneCard)
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                    secondPlayer.Add(playerOneCard);
                    secondPlayer.Add(playerTwoCard);
                }
                else
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }

            if (firstPlayer.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {Sum(firstPlayer)}");
            }
            else if (secondPlayer.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {Sum(secondPlayer)}");
            }
            else
            {
                Console.WriteLine("No player wins! Sum: 0");
            }
        }

        private static int Sum(List<int> list)
        {
            int sum = 0;
            foreach (int item in list)
            {
                sum += item;
            }

            return sum;
        }
    }
}
