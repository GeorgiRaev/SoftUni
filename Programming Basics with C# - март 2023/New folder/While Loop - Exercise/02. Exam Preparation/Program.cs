using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int filedTimes = int.Parse(Console.ReadLine());
            int evoluationCount = 0;
            int evoluationSum = 0;
            int filedCount = 0;
            int evoluation;
            string input = Console.ReadLine();
            string lastExercise = string.Empty;

            while (input != "Enough")
            {
                lastExercise = input;
                evoluation = int.Parse(Console.ReadLine());
                evoluationSum += evoluation;
                evoluationCount++;

                if (evoluation <= 4)
                {
                    filedCount++;
                    if (filedCount == filedTimes)
                    {
                        Console.WriteLine($"You need a break, {filedTimes} poor grades.");
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            if (input == "Enough")
            {
                Console.WriteLine($"Average score: {(double)evoluationSum/evoluationCount:f2}");
                Console.WriteLine($"Number of problems: {evoluationCount}");
                Console.WriteLine($"Last problem: {lastExercise}");
            }
        }
    }
}
