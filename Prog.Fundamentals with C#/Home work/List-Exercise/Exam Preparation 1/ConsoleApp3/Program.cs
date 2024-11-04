using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberStudents = double.Parse(Console.ReadLine());
            double numberLectures = double.Parse(Console.ReadLine());
            double additionalBonus = double.Parse(Console.ReadLine());
            double bestStudent = 0;
            double bonus = 0;

            for (int i = 0; i < numberStudents; i++)
            {
                double currentStudentAttendances = double.Parse(Console.ReadLine());
                double currentBonus = (currentStudentAttendances / numberLectures) * (5 + additionalBonus);
                if (bonus < currentBonus)
                {
                    bonus = currentBonus;
                    bestStudent = currentStudentAttendances;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(bonus)}.");
            Console.WriteLine($"The student has attended {bestStudent} lectures.");
        }
    }
}
