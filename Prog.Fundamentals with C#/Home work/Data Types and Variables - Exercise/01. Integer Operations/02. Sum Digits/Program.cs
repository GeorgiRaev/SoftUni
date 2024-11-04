using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            //string number = Console.ReadLine();
            //int num = 0;
            //for (int i = 0; i < number.Length; i++)
            //{
            //    num += int.Parse(number[i].ToString());
            //}
            //Console.WriteLine(num);
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            while (number != 0)
            {
                int digit = number % 10;
                sum += digit;
                number /= 10;
            }

            Console.WriteLine("The sum of the digits is: " + sum);
        }
    }
}
