using System;

namespace _05._PC_Game_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double allGames = 100.00/n;
            int hearthstoneCount = 0;
            int forniteCount = 0;
            int overwatchCount = 0;
            int othersCount = 0;
            for (int i = 0; i < n; i++)
            {
                string inputGame = Console.ReadLine();
                if (inputGame== "Hearthstone")
                {
                    hearthstoneCount++;
                }
                else if (inputGame=="Fornite")
                {
                    forniteCount++;
                }
                else if (inputGame== "Overwatch")
                {
                    overwatchCount++;
                }
                else
                {
                    othersCount++;
                }
            }
            Console.WriteLine($"Hearthstone - {hearthstoneCount * allGames:f2}%");
            Console.WriteLine($"Fornite - {forniteCount*allGames:f2}%");
            Console.WriteLine($"Overwatch - {overwatchCount*allGames:f2}%");
            Console.WriteLine($"Others - {othersCount*allGames:f2}%");
        }
    }
}
