using System;

//Action<string[]> print = (string[] strings) =>
//{
//    for (int i = 0; i < strings.Length; i++)
//    {
//        Console.WriteLine($"Sir {strings[i]}");
//    }
//};
//string[] strings = Console.ReadLine()
//    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
//print(strings);


Action<string[]> pringNamesWithAddedTitles = names =>
{
    foreach (var name in names)
    {
        Console.WriteLine($"Sir {name}");
    }
};

string[] input = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

pringNamesWithAddedTitles(input);
