using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double squareArea = a * a;
                Console.WriteLine($"{squareArea:F3}");
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double rectangleArea = a * b;
                Console.WriteLine($"{rectangleArea:F3}");
            }
            else if (figure == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                double cyrcleArea = a * a * 3.14159;
                Console.WriteLine($"{cyrcleArea:F3}");
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double triangleArea = (a * h) / 2;
                Console.WriteLine($"{triangleArea:F3}");
            }
        }
    }
}
