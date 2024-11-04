using System;

class Program
{
    static void Main()
    {
        string stops = Console.ReadLine();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Travel")
            {
                break;
            }

            string[] command = input.Split(":");
            string action = command[0];

            if (action == "Add Stop")
            {
                int index = int.Parse(command[1]);
                string stopToAdd = command[2];

                if (index >= 0 && index <= stops.Length)
                {
                    stops = stops.Insert(index, stopToAdd);
                }
            }
            else if (action == "Remove Stop")
            {
                int startIndex = int.Parse(command[1]);
                int endIndex = int.Parse(command[2]);

                if (startIndex >= 0 && endIndex < stops.Length && endIndex >= startIndex)
                {
                    stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                }
            }
            else if (action == "Switch")
            {
                string oldString = command[1];
                string newString = command[2];

                if (stops.Contains(oldString))
                {
                    stops = stops.Replace(oldString, newString);
                }
            }

            Console.WriteLine(stops);
        }

        Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
    }
}
