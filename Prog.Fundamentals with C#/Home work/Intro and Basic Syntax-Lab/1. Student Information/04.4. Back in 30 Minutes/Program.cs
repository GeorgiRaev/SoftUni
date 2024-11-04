using System;

namespace _04._4._Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int delay = 30;
            int time=minutes+delay;
            if (minutes + delay > 59)
            {
                hour++;
                time = (minutes + delay) - 60;
                if (hour > 23)
                {
                    hour = 0;
                }
                if (time<10)
                {
                    Console.WriteLine($"{hour}:0{time}");
                }
                else
                {
                    Console.WriteLine($"{hour}:{time}");
                }
            }
            else
            {
                if (time < 10)
                {
                    Console.WriteLine($"{hour}:0{time}");
                }
                else
                {
                    Console.WriteLine($"{hour}:{time}");

                }
                
            }
        }
    }
}
