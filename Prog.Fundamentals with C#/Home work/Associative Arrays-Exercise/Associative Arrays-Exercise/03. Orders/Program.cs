using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Quantity { get; set; }

    public Product(string name, double price, double quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    public void Update(double price, double quantity)
    {
        Price = price;
        Quantity += quantity;
    }
    public double TotalPrice => Price * Quantity;

    public override string ToString()
    {
        return $"{Name} -> {TotalPrice:f2}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Product> products = new Dictionary<string, Product>();

        string command;
        while ((command = Console.ReadLine()) != "buy")
        {
            string[] arguments = command.Split();
            string name = arguments[0];
            double price = double.Parse(arguments[1]);
            double quantity = double.Parse(arguments[2]);

            Product product = new Product(name, price, quantity);

            if (!products.ContainsKey(name))
            {
                products.Add(name, product);
            }
            else
            {
                products[name].Update(price, quantity);
            }
        }
        foreach (KeyValuePair<string, Product> pair in products)
        {
            Console.WriteLine(pair.Value);
        }
    }
}


