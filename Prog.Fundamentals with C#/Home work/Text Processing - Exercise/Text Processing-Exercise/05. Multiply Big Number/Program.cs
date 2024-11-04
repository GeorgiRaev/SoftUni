using System;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static string MultiplyLargeNumber(string largeNumber, int singleDigit)
        {
            if (singleDigit == 0 || largeNumber == "0")
                return "0";

            int carry = 0;
            int digit;
            string result = "";

            for (int i = largeNumber.Length - 1; i >= 0; i--)
            {
                int num = (largeNumber[i] - '0') * singleDigit + carry;
                digit = num % 10;
                carry = num / 10;

                result = digit + result;
            }

            if (carry > 0)
                result = carry + result;

            return result;
        }

        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());
            string product = MultiplyLargeNumber(firstNumber, secondNumber);
            Console.WriteLine(product);
        }
    }
}
