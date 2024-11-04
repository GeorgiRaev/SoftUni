using System;

namespace _05._Number_100._200
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            if (inputNumber < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (inputNumber >= 100 && inputNumber <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (inputNumber>200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
