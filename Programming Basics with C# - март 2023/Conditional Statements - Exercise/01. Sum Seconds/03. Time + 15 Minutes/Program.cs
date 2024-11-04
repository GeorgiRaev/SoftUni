using System;

namespace _03._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int extraTime = 15;
            if (minutes + extraTime > 59 && hour != 23)
            {
                hour++;
                minutes = (minutes + extraTime) - 60;
            }
            else if (minutes + extraTime > 59 && hour == 23)
            {
                hour = 0;
                minutes = (minutes + extraTime) - 60;
            }
            else
            {
                minutes = minutes + extraTime;
            }
            if (minutes < 10)
            {
                Console.WriteLine($"{hour}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hour}:{minutes}");
            }

        }
    }
}
