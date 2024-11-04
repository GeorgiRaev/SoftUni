using System;

namespace _04._Printsum
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            string counter = string.Empty;
            int sum = 0;
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                counter += i + " ";
                sum += i;                
            }
            Console.WriteLine(counter.Trim());
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
