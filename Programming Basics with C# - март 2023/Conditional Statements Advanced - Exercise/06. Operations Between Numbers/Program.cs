using System;

namespace _06._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double result = 0.00;
            string type = string.Empty;
            string symbol = Console.ReadLine();
            if (symbol == "/")
            {
                if (secondNumber == 0)
                {
                    Console.WriteLine($"Cannot divide {firstNumber} by zero");
                }
                else
                {
                    result = firstNumber / secondNumber;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{firstNumber} / {secondNumber} = {result:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"{firstNumber} / {secondNumber} = {result:F2}");
                    }
                }
            }
            else if (symbol == "*")
            {
                result = firstNumber * secondNumber;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{firstNumber} * {secondNumber} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{firstNumber} * {secondNumber} = {result} - odd");
                }
            }
            else if (symbol == "+")
            {
                result = firstNumber + secondNumber;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{firstNumber} + {secondNumber} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{firstNumber} + {secondNumber} = {result} - odd");
                }
            }
            else if (symbol == "-")
            {
                result = firstNumber - secondNumber;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{firstNumber} - {secondNumber} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{firstNumber} - {secondNumber} = {result} - odd");
                }
            }
            else if (symbol == "%")
            {
                if (secondNumber == 0)
                {
                    Console.WriteLine($"Cannot divide {firstNumber} by zero");
                }
                else
                {
                    result = firstNumber % secondNumber;
                    Console.WriteLine($"{firstNumber} % {secondNumber} = {result}");
                }                
            }
        }
    }
}
