using System;

namespace _04._Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int points = 0;
            int red = 0;
            int orange = 0;
            int yellow = 0;
            int white = 0;
            int otherColorsPicked = 0;
            int blackBalls = 0;


            for (int i = 0; i < n; i++)
            {
                string color = Console.ReadLine();
                if (color=="red")
                {
                    points += 5;
                    red++;
                }
                else if (color=="orange")
                {
                    points += 10;
                    orange++;
                }
                else if (color=="yellow")
                {
                    points += 15;
                    yellow++;
                }
                else if (color=="white")
                {
                    points += 20;
                    white++;
                }
                else if (color=="black")
                {
                    points /= 2;
                    blackBalls++;
                }
                else
                {
                    otherColorsPicked++;
                    continue;
                }
            }
            Console.WriteLine($"Total points: {points}");
            Console.WriteLine($"Red balls: {red}");
            Console.WriteLine($"Orange balls: {orange}");
            Console.WriteLine($"Yellow balls: {yellow}");
            Console.WriteLine($"White balls: {white}");
            Console.WriteLine($"Other colors picked: {otherColorsPicked}");
            Console.WriteLine($"Divides from black balls: {blackBalls}");
        }
    }
}
