using System;

namespace Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int result = Math.Max(firstNumber, secondNumber);
            Console.WriteLine(result);
        }
    }
}
