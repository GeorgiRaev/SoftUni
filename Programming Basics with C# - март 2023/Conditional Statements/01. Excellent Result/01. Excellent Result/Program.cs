using System;

namespace _01._Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = double.Parse(Console.ReadLine());
            string invalid = string.Empty;
            if (result>=5.50 && result<=6)
            {
                Console.WriteLine("Excellent!");
            }
            else
            {
                Console.WriteLine(invalid);
            }
        }
    }
}
