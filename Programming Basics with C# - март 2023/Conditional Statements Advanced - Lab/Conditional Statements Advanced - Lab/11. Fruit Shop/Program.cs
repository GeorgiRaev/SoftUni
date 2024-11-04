using System;

namespace _11._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;
            if (fruit != "banana" && fruit != "apple" && fruit != "orange" && fruit != "grapefruit" && fruit != "kiwi" && fruit != "pineapple" && fruit != "grapes")
            {
                Console.WriteLine("error");
            }
            else if (day != "Monday" && day != "Tuesday" && day != "Wednesday" && day != "Thursday" && day != "Friday"&& day != "Saturday" && day != "Sunday")
            {
                Console.WriteLine("error");
            }
            if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana")
                {
                    price = 2.70;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "apple")
                {
                    price = 1.25;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "orange")
                {
                    price = 0.90;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.60;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "kiwi")
                {
                    price = 3.00;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "pineapple")
                {
                    price = 5.60;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "grapes")
                {
                    price = 4.20;
                    Console.WriteLine($"{price * quantity:F2}");
                }
            }
            else if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    price = 2.50;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "apple")
                {
                    price = 1.20;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "orange")
                {
                    price = 0.85;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.45;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "kiwi")
                {
                    price = 2.70;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "pineapple")
                {
                    price = 5.50;
                    Console.WriteLine($"{price * quantity:F2}");
                }
                else if (fruit == "grapes")
                {
                    price = 3.85;
                    Console.WriteLine($"{price * quantity:F2}");
                }
            }                        
        }
    }
}
