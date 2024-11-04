using System;

namespace _10._Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string result = string.Empty;
            if (number >= 100 && number <= 200 || number == 0)
            {
                Console.WriteLine(result);
            }
            else
            {
                result = "invalid";
                Console.WriteLine(result);
            }
        }
    }
}
