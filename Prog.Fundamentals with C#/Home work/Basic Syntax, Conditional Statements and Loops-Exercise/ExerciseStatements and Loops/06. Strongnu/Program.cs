using System;

namespace _06._Strongnu
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string numberAsString = number.ToString();
            int sum = 0;
            for (int i = 0; i < numberAsString.Length; i++)
            {

                int currentNumber = (int)numberAsString.ToString()[i] - 48;
                int currentSum = 1;

                for (int j = currentNumber; j >= 1; j--)
                {
                    currentSum *= j;
                }
                sum += currentSum;
            }
            if (number == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
