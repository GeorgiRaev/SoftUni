using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int ballsCount = int.Parse(Console.ReadLine());
            int bestSnow = 0;
            int bestTime = 0;
            int bestQuality = 0;
            BigInteger bestValue = 0;

            for (int i = 0; i < ballsCount; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

                //(snowballSnow / snowballTime) ^ snowballQuality
                //ulong value = (ulong)Math.Pow(snow / time, quality);

                BigInteger value = BigInteger.Pow(snow / time, quality);

                if (bestValue < value)
                {
                    bestSnow = snow;
                    bestTime = time;
                    bestQuality = quality;
                    bestValue = value;
                }
            }
            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");
        }
    }
}
