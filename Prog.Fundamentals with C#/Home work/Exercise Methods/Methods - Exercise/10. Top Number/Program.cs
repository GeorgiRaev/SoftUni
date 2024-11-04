using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool IsTopNumber(int num)
        {
            if (IsDivisibleByEight(num) && HasOddNumber(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool HasOddNumber(int num)
        {
            while (num > 0)
            {
                int digit = num % 10;
                if (digit % 2 != 0)
                {
                    return true;
                }
                num /= 10;

            }
            return false;
        }
        static bool IsDivisibleByEight(int num)
        {
            int sumOfAllDigits = 0;
            while (num > 0)
            {
                int digit = num % 10;
                sumOfAllDigits += digit;
                num /= 10;

            }
            return sumOfAllDigits % 8 == 0; ;
        }
    }
}
