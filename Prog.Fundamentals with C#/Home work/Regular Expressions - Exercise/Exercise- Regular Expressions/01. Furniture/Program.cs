using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Furniture
    {
        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Furniture> furnitures = new List<Furniture>();
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+|\d+\.\d+)!(?<quantity>\d+)";
            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {

                foreach (Match match in Regex.Matches(input, pattern))
                {

                    string name = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);

                    Furniture f = new Furniture(name, price, quantity);
                    furnitures.Add(f);
                }
            }

            Console.WriteLine("Bought furniture:");
            decimal totalSpend = 0;
            foreach  (Furniture furniture in furnitures)
            {
                Console.WriteLine(furniture.Name);
                totalSpend += furniture.Total();
            }
            Console.WriteLine($"Total money spend: {totalSpend:f2}");
        }
    }
}
