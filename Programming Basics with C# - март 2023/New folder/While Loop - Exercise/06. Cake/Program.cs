using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int pieceOfCake = a * b;
            string input = string.Empty;
            int currentPieceCake;
            while (pieceOfCake > 0)
            {
                input = Console.ReadLine();
                if (input != "STOP")
                {
                    currentPieceCake = int.Parse(input);
                    if (currentPieceCake > pieceOfCake)
                    {
                        Console.WriteLine($"No more cake left! You need {currentPieceCake - pieceOfCake} pieces more.");
                        break;
                    }
                    else
                    {
                        pieceOfCake -= currentPieceCake;
                    }
                }
                else if (input == "STOP")
                {
                    Console.WriteLine($"{pieceOfCake} pieces are left.");
                    break;
                }
            }
        }
    }
}
