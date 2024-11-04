using System;

namespace _05._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabsNumber = int.Parse(Console.ReadLine());
            double selary = double.Parse(Console.ReadLine());

            for (int i = 0; i < tabsNumber; i++)
            {
                string tabName = Console.ReadLine();
                if (tabName == "Facebook")
                {
                    selary -= 150;
                }
                else if (tabName == "Instagram")
                {
                    selary -= 100;
                }
                else if (tabName == "Reddit")
                {
                    selary -= 50;
                }
                if (selary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (selary > 0)
            {
                Console.WriteLine(selary);
            }
        }
    }
}
