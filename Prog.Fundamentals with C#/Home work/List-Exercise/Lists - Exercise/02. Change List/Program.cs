using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string commands;
            while ((commands = Console.ReadLine()) != "end")
            {
                string[] arguments = commands.Split();
                int index;
                if (arguments[0] == "Delete")
                {
                    int item = int.Parse(arguments[1]);
                    integers.Remove(item);
                    
                }
                else if (arguments[0] == "Insert")
                {
                    int item = int.Parse(arguments[1]);
                     index = int.Parse(arguments[2]);
                    integers.Insert(index, item);
                    
                }
            }
            Console.WriteLine(string.Join(" ",integers));
        }
    }
}
