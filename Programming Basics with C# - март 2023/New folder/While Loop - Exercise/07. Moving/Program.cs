using System;

namespace _07._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int legth = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double freeSpace = width * legth * height;
            string input = Console.ReadLine();
            while (input != "Done")
            {
                double currentBox = double.Parse(input);

                freeSpace = freeSpace - currentBox;


                if (freeSpace < 0)
                {
                    Console.WriteLine("No more free space! You need " + Math.Abs(freeSpace) + " Cubic meters more.");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(freeSpace + " Cubic meters left.");
        }
    }
}
