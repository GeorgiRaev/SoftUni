using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<int> armours = new Queue<int>(Console.ReadLine()
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        Stack<int> strikes = new Stack<int>(Console.ReadLine()
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        int monstersKilled = 0;

        while (armours.Any() && strikes.Any())
        {
            int armour = armours.Dequeue();
            int strike = strikes.Pop();

            if (strike >= armour)
            {
                monstersKilled++;
            }
            else
            {
                armours.Enqueue(armour - strike);
            }
        }

        if (armours.Count == 0)
        {
            Console.WriteLine("All monsters have been killed!");
        }
        else
        {
            Console.WriteLine("The soldier has been defeated.");
        }

        Console.WriteLine($"Total monsters killed: {monstersKilled}");
    }
}
