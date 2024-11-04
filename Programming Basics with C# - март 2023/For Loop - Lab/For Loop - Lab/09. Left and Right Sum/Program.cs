using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int digit = 2 * n;
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 1; i <= digit; i++)
            {
                if (i <= digit / 2)
                {
                    sum1 += int.Parse(Console.ReadLine());
                }
                else if (i > digit / 2)
                {
                    sum2 += int.Parse(Console.ReadLine());
                }
            }
            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else if (sum1 > sum2)
            {
                Console.WriteLine($"No, diff = {sum1 - sum2}");
            }
            else if (sum1 < sum2)
            {
                Console.WriteLine($"No, diff = {sum2 - sum1}");
            }
        }
    }
}
