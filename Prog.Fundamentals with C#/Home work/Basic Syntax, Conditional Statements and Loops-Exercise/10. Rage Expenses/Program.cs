using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double totalPriceForHeadset = 0;
            double mousePrice = double.Parse(Console.ReadLine());
            double totalPriceForMouse = 0;
            double keyboardPrice = double.Parse(Console.ReadLine());
            double totalPriceForKeyboard = 0;
            double displayPrice = double.Parse(Console.ReadLine());
            double totalPriceForDisplay = 0;
            int keyboardTrashCount = 0;
            double totalExpenses = 0;
            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    totalPriceForHeadset += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    totalPriceForMouse += mousePrice;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    totalPriceForKeyboard += keyboardPrice;
                    keyboardTrashCount++;
                    if (keyboardTrashCount % 2 == 0)
                    {
                        totalPriceForDisplay += displayPrice;
                    }
                }
            }
            totalExpenses = totalPriceForHeadset + totalPriceForMouse + totalPriceForKeyboard + totalPriceForDisplay;
            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
