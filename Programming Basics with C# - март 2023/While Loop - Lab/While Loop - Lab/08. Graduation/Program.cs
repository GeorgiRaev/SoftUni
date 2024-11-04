using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int currentGrade = 1;
            int repeats = 0;
            bool isExluded = false;
            double marksSum = 0;
            while (currentGrade <= 12)
            {
                double currentMark = double.Parse(Console.ReadLine());
                if (currentMark < 4)
                {
                    repeats++;
                    if (repeats > 1)
                    {
                        isExluded = true;
                        break;
                    }
                    continue;
                }
                marksSum += currentMark;
                currentGrade++;
            }
            if (isExluded == true)
            {
                Console.WriteLine($"{studentName} has been excluded at {currentGrade} grade");
            }
            else
            {
                double average = marksSum / 12;
                Console.WriteLine($"{studentName} graduated. Average grade: {average:f2}");
            }
        }
    }
}
