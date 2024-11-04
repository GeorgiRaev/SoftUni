using System;
using System.Collections.Generic;

namespace WordNotebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordDictionary = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            string[] wordsAndDefinitions = input.Split(" | ");
            foreach (var wordDefinition in wordsAndDefinitions)
            {
                string[] wordAndDefinitions = wordDefinition.Split(": ");
                string word = wordAndDefinitions[0];
                string definition = wordAndDefinitions[1];

                if (wordDictionary.ContainsKey(word))
                {
                    wordDictionary[word].Add(definition);
                }
                else
                {
                    wordDictionary[word] = new List<string> { definition };
                }
            }

            string testWordsInput = Console.ReadLine();
            string[] testWords = testWordsInput.Split(" | ");
            string command = Console.ReadLine();

            if (command == "Test")
            {
                foreach (var testWord in testWords)
                {
                    if (wordDictionary.ContainsKey(testWord))
                    {
                        Console.WriteLine($"{testWord}:");
                        foreach (var definition in wordDictionary[testWord])
                        {
                            Console.WriteLine($"-{definition}");
                        }
                    }
                }
            }
            else if (command == "Hand Over")
            {
                Console.WriteLine(string.Join(" ", wordDictionary.Keys));
            }
        }
    }
}
