using System;

namespace _04._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberGroups = int.Parse(Console.ReadLine());
            double musala = 0;
            double monblan = 0;
            double kilimanjaro = 0;
            double k2 = 0;
            double everest = 0;
            int numberClimbers = 0;
            for (int i = 0; i < numberGroups; i++)
            {
                int countClimbers = int.Parse(Console.ReadLine());
                numberClimbers += countClimbers;
                if (countClimbers <= 5)
                {
                    musala += countClimbers;
                }
                else if (countClimbers > 5 && countClimbers <= 12)
                {
                    monblan += countClimbers;
                }
                else if (countClimbers > 12 && countClimbers <= 25)
                {
                    kilimanjaro += countClimbers;
                }
                else if (countClimbers > 25 && countClimbers <= 40)
                {
                    k2 += countClimbers;
                }
                else if (countClimbers > 40)
                {
                    everest += countClimbers;
                }
            }
            musala=(musala/numberClimbers)*100;           
            monblan = (monblan / numberClimbers) * 100;
            kilimanjaro = (kilimanjaro / numberClimbers) * 100;
            k2 = (k2 / numberClimbers) * 100;
            everest = (everest / numberClimbers) * 100;
            Console.WriteLine($"{musala:f2}%");
            Console.WriteLine($"{monblan:f2}%");
            Console.WriteLine($"{kilimanjaro:f2}%");
            Console.WriteLine($"{k2:f2}%");
            Console.WriteLine($"{everest:f2}%");
        }
    }
}
