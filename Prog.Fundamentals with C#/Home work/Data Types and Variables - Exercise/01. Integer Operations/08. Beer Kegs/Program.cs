using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegsCount = int.Parse(Console.ReadLine());           
            double biggerKeg = 0;
            string model = string.Empty;
            for (int i = 1; i <= kegsCount; i++)
            {
                string currentModel = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double currentVolume = Math.PI * (radius*radius) * height;
                if (currentVolume>biggerKeg)
                {
                    biggerKeg = currentVolume;
                    model = currentModel;
                }
            }
            Console.WriteLine(model);
        }
    }
}
