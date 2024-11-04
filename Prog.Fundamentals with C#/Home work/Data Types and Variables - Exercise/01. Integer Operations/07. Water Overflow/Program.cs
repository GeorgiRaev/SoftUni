using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRow = int.Parse(Console.ReadLine());
            int waterTank = 255;
            int sumOfLitters = 0;
            for (int i = 1; i <= numberOfRow; i++)
            {
                int currentLitters = int.Parse(Console.ReadLine());
                if (waterTank < currentLitters + sumOfLitters)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sumOfLitters += currentLitters;
                }
            }
            Console.WriteLine(sumOfLitters);
        }
    }
}
