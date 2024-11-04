using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double coin = 0;
            double totalSum = 0;
            while (input != "Start")
            {
                input = Console.ReadLine();
                if (input == "0.1" || input == "0.2" || input == "0.5" || input == "1" || input == "2")
                {
                    coin = double.Parse(input);
                    totalSum += coin;
                }
                else if (input == "Start")
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {input}");
                }
            }

            while (input != "End")
            {
                input = Console.ReadLine();
                if (input == "Nuts")
                {
                    if (totalSum >= 2)
                    {
                        Console.WriteLine("Purchased nuts");
                        totalSum -= 2;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Water")
                {
                    if (totalSum >= 0.70)
                    {
                        Console.WriteLine("Purchased water");
                        totalSum -= 0.70;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Crisps")
                {
                    if (totalSum >= 1.50)
                    {
                        Console.WriteLine("Purchased crisps");
                        totalSum -= 1.50;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Soda")
                {
                    if (totalSum >= 0.80)
                    {
                        Console.WriteLine("Purchased soda");
                        totalSum -= 0.80;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Coke")
                {
                    if (totalSum >= 1)
                    {
                        Console.WriteLine("Purchased coke");
                        totalSum -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input=="End")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine($"Change: {totalSum:f2}");
        }
    }
}
