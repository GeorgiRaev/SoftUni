﻿using System;

namespace _06._BarcodeGener
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int firstStart = start / 1000;
            int secondStart = (start / 100) % 10;
            int thirdStart = (start / 10) % 10;
            int fourtStart = start % 10;

            int firstEnd = end / 1000;
            int secondEnd = (end / 100) % 10;
            int thirdEnd = (end / 10) % 10;
            int fourtEnd = end % 10;
            for (int i = firstStart; i <= firstEnd; i++)
            {
                for (int j = secondStart; j <= secondEnd; j++)
                {
                    for (int k = thirdStart; k <= thirdEnd; k++)
                    {
                        for (int l = fourtStart; l <= fourtEnd; l++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 && k % 2 != 0 && l % 2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
