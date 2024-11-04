using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int years = int.Parse(Console.ReadLine());
            double mashineWashPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            double saveMoney = 0;

            for (int i = 1; i <= years; i++)
            {
                if (i % 2 == 0)
                {
                    saveMoney += i * 5 - 1;
                }
                else
                {
                    saveMoney += toyPrice;
                }
            }
            if (saveMoney >= mashineWashPrice)
            {
                Console.WriteLine($"Yes! {saveMoney-mashineWashPrice:F2}");
            }
            else
            {
                Console.WriteLine($"No! {mashineWashPrice-saveMoney:F2}");
            }
        }
    }
}
