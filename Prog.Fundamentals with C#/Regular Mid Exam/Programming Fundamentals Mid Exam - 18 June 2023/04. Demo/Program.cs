using System;
using System.Collections.Generic;
using System.Linq;
/*
Mike, John, Eddie
Blacklist Mike
Error 0
Report
------------------------
Mike was blacklisted.
Blacklisted names: 1 
Lost names: 0 
Blacklisted John Eddie
 
Mike, John, Eddie, William
Error 3
Error 3
Change 0 Mike123
Report
------------------------
William was lost due to an error. 
Mike changed his username to Mike123. 
Blacklisted names: 0 
Lost names: 1 
Mike123 John Eddie Lost
 
Mike, John, Eddie, William
Blacklist Maya
Error 1
Change 4 George
Report
--------------------------
Maya was not found. 
John was lost due to an error. 
Blacklisted names: 0 
Lost names: 1 
Mike Lost Eddie William

 */
namespace _02._Friend_List_Mainten
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command;
            int lostedCount = 0;
            int blacklistedCount = 0;

            while ((command = Console.ReadLine()) != "Report")
            {
                string[] commandAction = command.Split();
                string action = commandAction[0];

                if (action == "Blacklist")
                {
                    string name = commandAction[1];
                    if (friendsList.Contains(name))
                    {
                        int indexOfFriend = friendsList.IndexOf(name);
                        Console.WriteLine($"{name} was blacklisted.");
                        friendsList[indexOfFriend] = "Blacklisted";
                        blacklistedCount++;
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (action == "Error")
                {
                    int indexOfFriend = int.Parse(commandAction[1]);
                    if (indexOfFriend >= 0 && indexOfFriend < friendsList.Count && friendsList[indexOfFriend] != "Blacklisted" && friendsList[indexOfFriend] != "Lost")
                    {
                        Console.WriteLine($"{friendsList[indexOfFriend]} was lost due to an error.");
                        friendsList[indexOfFriend] = "Lost";
                        lostedCount++;
                    }
                }
                else if (action == "Change")
                {
                    int indexOfFriend = int.Parse(commandAction[1]);
                    string newName = commandAction[2];
                    if (indexOfFriend >= 0 && indexOfFriend < friendsList.Count)
                    {
                        string currentName = friendsList[indexOfFriend];
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                        friendsList[indexOfFriend] = newName;
                    }
                }
            }
            Console.WriteLine($"Blacklisted names: {blacklistedCount}");
            Console.WriteLine($"Lost names: {lostedCount}");
            Console.WriteLine(string.Join(" ", friendsList));
        }
    }
}
