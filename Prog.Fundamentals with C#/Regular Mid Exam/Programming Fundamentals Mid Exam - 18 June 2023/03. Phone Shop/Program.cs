using System;
using System.Collections.Generic;
using System.Linq;
/*
SamsungA50, MotorolaG5, IphoneSE
Add - Iphone10
Remove - IphoneSE                                       
End
-------------------------
SamsungA50, MotorolaG5, Iphone10

HuaweiP20, XiaomiNote
Remove - Samsung
Bonus phone - XiaomiNote:Iphone5                        
End
-------------------------
HuaweiP20, XiaomiNote, Iphone5

SamsungA50, MotorolaG5, HuaweiP10
Last - SamsungA50
Add - MotorolaG5                                        
End
------------------------
MotorolaG5, HuaweiP10, SamsungA50
 */
namespace _03._Phone_Shop
{
    class Program
    {
        static void Main(string[] args)
        {         
            List<string> phones = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandParts = command.Split(" - ");
                string action = commandParts[0];
                string phone = commandParts[1];

                if (action == "Add")
                {
                    if (!phones.Contains(phone))
                    {
                        phones.Add(phone);
                    }
                }
                else if (action == "Remove")
                {
                    phones.Remove(phone);
                }
                else if (action == "Bonus phone")
                {
                    string[] bonusParts = phone.Split(":");
                    string oldPhone = bonusParts[0];
                    string newPhone = bonusParts[1];

                    int index = phones.IndexOf(oldPhone);
                    if (index != -1)
                    {
                        phones.Insert(index + 1, newPhone);
                    }
                }
                else if (action == "Last")
                {
                    if (phones.Contains(phone))
                    {
                        phones.Remove(phone);
                        phones.Add(phone);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
