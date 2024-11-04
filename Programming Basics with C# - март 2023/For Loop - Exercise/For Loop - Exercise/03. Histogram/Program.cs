using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < 200)
                {
                    p1++;
                }
                else if (currentNumber >= 200 && currentNumber < 400)
                {
                    p2++;
                }
                else if (currentNumber >= 400 && currentNumber < 600)
                {
                    p3++;
                }
                else if (currentNumber >= 600 && currentNumber < 800)
                {
                    p4++;
                }
                else if (currentNumber >= 800)
                {
                    p5++;
                }
            }
            double resultP1 = p1 / n * 100;
            double resultP2 = p2 / n * 100;
            double resultP3 = p3 / n * 100;
            double resultP4 = p4 / n * 100;
            double resultP5 = p5 / n * 100;
            Console.WriteLine($"{resultP1:F2}%");
            Console.WriteLine($"{resultP2:F2}%");
            Console.WriteLine($"{resultP3:F2}%");
            Console.WriteLine($"{resultP4:F2}%");
            Console.WriteLine($"{resultP5:F2}%");
        }
    }
}
