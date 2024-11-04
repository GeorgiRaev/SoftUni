using System;

namespace FirsStepInPrograming
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareМeters = double.Parse(Console.ReadLine());
            double coastSquareMeters = 7.61;
            double discountPErcent = 0.18;
            double totalCoast = squareМeters * coastSquareMeters;
            double discount = discountPErcent * totalCoast;
            double finalPrice = totalCoast - discount;
            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
