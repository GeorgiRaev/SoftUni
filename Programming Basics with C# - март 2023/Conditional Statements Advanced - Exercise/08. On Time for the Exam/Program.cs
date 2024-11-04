using System;

namespace _08._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arraveMinutes = int.Parse(Console.ReadLine());
            int examTime = examHour * 60 + examMinutes;
            int arrivelTime = arriveHour * 60 + arraveMinutes;
            if (arrivelTime > examTime)
            {
                Console.WriteLine("Late");
                if (arrivelTime - examTime < 60)
                {
                    Console.WriteLine($"{arrivelTime - examTime} minutes after the start");
                }
                else
                {
                    int hour = (arrivelTime - examTime) / 60;
                    int minutes = (arrivelTime - examTime) % 60;
                    Console.WriteLine($"{hour}:{minutes:D2} hours after the start");
                }
            }
            else if (arrivelTime == examTime || examTime - arrivelTime <= 30)
            {
                Console.WriteLine("On time");
                if (examTime - arrivelTime != 0)
                {
                    int minutes = examTime - arrivelTime;
                    Console.WriteLine($"{minutes} minutes before the start");
                }
            }
            else if (examTime - arrivelTime > 30)
            {
                Console.WriteLine("Early");
                if (examTime - arrivelTime < 60)
                {
                    int minutes = examTime - arrivelTime;
                    Console.WriteLine($"{minutes} minutes before the start");
                }
                else
                {
                    int hours = (examTime - arrivelTime) / 60;
                    int minutes = (examTime - arrivelTime) % 60;
                    Console.WriteLine($"{hours}:{minutes:D2} hours before the start");
                }
            }
        }
    }
}
