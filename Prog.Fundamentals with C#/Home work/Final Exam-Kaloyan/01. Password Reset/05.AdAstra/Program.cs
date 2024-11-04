using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _05.AdAstra
{
    class Program
    {

        static void Main(string[] args)
        {
            int caloriesPerDay = 2000;
            string input = Console.ReadLine();
            string pattern = @"(#|\|)([a-zA-Z\s]+)(\1)(\d{2}\/\d{2}\/\d{2})(\1)(\d+)(\1)";

            RegexOptions options = RegexOptions.Multiline;
            List<Product> products = new List<Product>();
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                string itemName = m.Groups[2].Value;
                string expirationDate = m.Groups[4].Value;
                int calories = int.Parse(m.Groups[6].Value);
                products.Add(new Product(itemName, expirationDate, calories));
            }

            double days = products.Sum(x => x.Calories) / caloriesPerDay;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Product product in products)
            {
                Console.WriteLine($"Item: {product.Name}, Best before: {product.ExpirationDate}, Nutrition: {product.Calories}");
            }
        }
    }
    public class Product
    {
        public Product(string name, string expirationDate, int calories)
        {
            Name = name;
            ExpirationDate = expirationDate;
            Calories = calories;
        }
        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public int Calories { get; set; }

    }
}
