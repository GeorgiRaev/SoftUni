﻿using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num > max)
                {
                    max = num;
                }
            }
            int sumWithoutMax = sum - max;
            if (sumWithoutMax == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumWithoutMax}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumWithoutMax - max)}");
            }
        }
    }
}
