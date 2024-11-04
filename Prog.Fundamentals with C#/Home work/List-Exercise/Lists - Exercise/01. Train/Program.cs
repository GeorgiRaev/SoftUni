using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        private static object invontary;

        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int capacityWagon = int.Parse(Console.ReadLine());
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cammandInput = command.Split();
                if (cammandInput[0] == "Add")
                {
                    wagons.Add(int.Parse(cammandInput[1]));
                }
                else
                {
                    int newPassenger = int.Parse(cammandInput[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + newPassenger <= capacityWagon)
                        {
                            wagons[i] += newPassenger;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
