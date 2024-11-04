using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            double result = Factorial(first) / Factorial(second);
            Console.WriteLine($"{result:f2}");
        }

        private static double Factorial(int number)
        {
            double result = number;
            for (double i = number - 1; i >= 1 ; i--)
            {
                result *= i;
            }
            return (double)result;
        }
    }
}
