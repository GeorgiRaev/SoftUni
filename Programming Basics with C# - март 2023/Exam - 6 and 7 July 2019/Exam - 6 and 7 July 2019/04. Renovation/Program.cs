using System;

namespace _04._Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int hightWall = int.Parse(Console.ReadLine());
            int widthWall = int.Parse(Console.ReadLine());
            double spaceNoPainted = double.Parse(Console.ReadLine());
            spaceNoPainted = spaceNoPainted / 100;
            string input = string.Empty;
            int inputIsNumber = 0;
            double totalArea = hightWall * widthWall * 4;
            totalArea -= totalArea * spaceNoPainted;
            while (input != "Tired!")
            {
                input = Console.ReadLine();
                bool isParsingSuccessful = int.TryParse(input, out inputIsNumber);
                if (isParsingSuccessful==true)
                {
                    totalArea -= inputIsNumber;
                }               
                if (totalArea <= 0)
                {
                    break;
                }
            }
            if (input == "Tired!")
            {
                Console.WriteLine($"{totalArea} quadratic m left.");
            }
            else if (totalArea == 0)
            {
                Console.WriteLine($"All walls are painted! Great job, Pesho!");
            }
            else if (totalArea < inputIsNumber)
            {                
                Console.WriteLine($"All walls are painted and you have {Math.Abs(totalArea)} l paint left!");
            }
        }
    }
}
