using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> notebook = new Dictionary<string, List<string>>();

        string inputWordsAndDefinitions = Console.ReadLine();
        string[] wordsAndDefinitions = inputWordsAndDefinitions.Split(" | ");
        foreach (var wordDef in wordsAndDefinitions)
        {
            string[] wordData = wordDef.Split(": ");
            string word = wordData[0];
            string definition = wordData[1];

            if (!notebook.ContainsKey(word))
            {
                notebook[word] = new List<string>();
            }

            notebook[word].Add(definition);
        }

        string[] wordsToTest = Console.ReadLine().Split(" | ");
        string command = Console.ReadLine();

        if (command == "Test")
        {
            foreach (var wordToTest in wordsToTest)
            {
                if (notebook.ContainsKey(wordToTest))
                {
                    Console.WriteLine($"{wordToTest}:");
                    foreach (var definition in notebook[wordToTest])
                    {
                        Console.WriteLine($"- {definition}");
                    }
                }
            }
        }
        else if (command == "Hand Over")
        {
            Console.WriteLine(string.Join(" ", notebook.Keys));
        }
    }
}
