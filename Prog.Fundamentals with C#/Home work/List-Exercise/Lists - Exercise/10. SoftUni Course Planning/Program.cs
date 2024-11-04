using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ")
                .ToList();
            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "course start")
            {
                string[] arguments = commands.Split(":");
                switch (arguments[0])
                {
                    case "Add":
                        schedule = AddTitle(schedule,arguments[1]);
                        break;
                    case "Insert":
                        schedule = InserTitle(schedule, arguments[1], arguments[2]);
                        break;
                    case "Remove":
                        schedule = RemuveTitle(schedule, arguments[1]);
                        break;
                    case "Swap":
                        schedule = AddTitle(schedule, arguments[1]);
                        break;
                    case "Exercise":
                        schedule = AddTitle(schedule, arguments[1]);
                        break;

                }
            }


            Console.WriteLine(string.Join(" ", schedule));
        }
    }
}
