using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupNumber = int.Parse(Console.ReadLine());
            double groupMusala = 0;
            double groupMonblan = 0;
            double groupKilimandjaro = 0;
            double groupK2 = 0;
            double groupEverest = 0;
            double allClimbers = 0;
            for (int i = 1; i <= groupNumber; i++)
            {
                int currentGroupNumber = int.Parse(Console.ReadLine());
                allClimbers += currentGroupNumber;
                if (currentGroupNumber <= 5)
                {
                    groupMusala += currentGroupNumber;
                }
                else if (currentGroupNumber > 5 && currentGroupNumber <= 12)
                {
                    groupMonblan += currentGroupNumber;
                }
                else if (currentGroupNumber > 12 && currentGroupNumber <= 25)
                {
                    groupKilimandjaro += currentGroupNumber;
                }
                else if (currentGroupNumber > 25 && currentGroupNumber <= 40)
                {
                    groupK2 += currentGroupNumber;
                }
                else if (currentGroupNumber > 40)
                {
                    groupEverest += currentGroupNumber;
                }
            }
            groupMusala = groupMusala / allClimbers * 100;
            groupMonblan = groupMonblan / allClimbers * 100;
            groupKilimandjaro = groupKilimandjaro / allClimbers * 100;
            groupK2 = groupK2 / allClimbers * 100;
            groupEverest = groupEverest / allClimbers * 100;
            Console.WriteLine($"{groupMusala:f2}%");
            Console.WriteLine($"{groupMonblan:f2}%");
            Console.WriteLine($"{groupKilimandjaro:f2}%");
            Console.WriteLine($"{groupK2:f2}%");
            Console.WriteLine($"{groupEverest:f2}%");
        }
    }
}
