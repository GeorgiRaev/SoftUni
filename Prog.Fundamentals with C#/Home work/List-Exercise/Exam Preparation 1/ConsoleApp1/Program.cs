using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double totalWithoutTaxws = 0;

            while (true)
            {
                input = Console.ReadLine();
                if (input == "regular")
                {
                    if (totalWithoutTaxws == 0)
                    {
                        Console.WriteLine("Invalid order!");
                        break;
                    }
                    if (totalWithoutTaxws > 0)
                    {
                        Console.WriteLine("Congratulations you've just bought a new computer!");
                        Console.WriteLine($"Price without taxes: {totalWithoutTaxws:f2}$");
                        Console.WriteLine($"Taxes: {(totalWithoutTaxws * 0.2):f2}$");
                        Console.WriteLine("-----------");
                        Console.WriteLine($"Total price: {(totalWithoutTaxws + totalWithoutTaxws * 0.2):f2}$");
                        break;
                    }
                }
                if (input == "special")
                {
                    if (totalWithoutTaxws == 0)
                    {
                        Console.WriteLine("Invalid order!");
                        break;
                    }
                    if (totalWithoutTaxws > 0)
                    {
                        Console.WriteLine("Congratulations you've just bought a new computer!");
                        Console.WriteLine($"Price without taxes: {totalWithoutTaxws:f2}$");
                        Console.WriteLine($"Taxes: {(totalWithoutTaxws * 0.2):f2}$");
                        Console.WriteLine("-----------");
                        Console.WriteLine($"Total price: {(totalWithoutTaxws + totalWithoutTaxws * 0.2) * (0.9):f2}$");
                        break;
                    }
                }
                if (double.Parse(input) < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                else
                {
                    totalWithoutTaxws += double.Parse(input);
                }
            }
        }
    }
}
