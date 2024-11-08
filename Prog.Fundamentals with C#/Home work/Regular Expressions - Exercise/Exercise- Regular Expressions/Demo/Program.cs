﻿using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string pattern = @"%([A-Z][a-z]+)%.*?<(\w+)>.*?\|(\d+)\|.*?(\d+\.?\d*)\$";
        Regex regex = new Regex(pattern);

        decimal totalIncome = 0;

        string input;
        while ((input = Console.ReadLine()) != "end of shift")
        {
            Match match = regex.Match(input);
            if (match.Success)
            {
                string customer = match.Groups[1].Value;
                string product = match.Groups[2].Value;
                int count = int.Parse(match.Groups[3].Value);
                decimal price = decimal.Parse(match.Groups[4].Value);

                decimal totalPrice = count * price;
                totalIncome += totalPrice;

                Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
            }
        }
        Console.WriteLine($"Total income: {totalIncome:f2}");
    }
}
