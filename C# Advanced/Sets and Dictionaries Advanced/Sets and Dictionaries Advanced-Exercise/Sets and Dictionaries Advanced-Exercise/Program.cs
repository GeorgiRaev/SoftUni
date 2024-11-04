using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_and_Dictionaries_Advanced_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> uniqueUserNames = new HashSet<string>();

            for (int i = 1; i <= number; i++)
            {
                string userName = Console.ReadLine();
                uniqueUserNames.Add(userName);
            }
            foreach (var userName in uniqueUserNames)
            {
                Console.WriteLine(userName);
            }
        }
    }
}
