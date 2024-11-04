using System;

namespace _01._Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firsTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            int result = firsTime + secondTime + thirdTime;
            int minutes = result / 60;
            int second = result % 60;
            if (second<10)
            {
                Console.WriteLine($"{minutes}:0{second}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{second}");
            }
        }
    }
}
