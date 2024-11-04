using System;

Action<string[]> print = (string[] strings) =>
{
    for (int i = 0; i < strings.Length; i++)
    {
        Console.WriteLine(strings[i]);
    }
};
string[] strings = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
print (strings);