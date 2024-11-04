using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == ' ')
                {
                    continue;
                }
                if (!charOccurrences.ContainsKey(currentChar))
                {
                    charOccurrences.Add(currentChar, 1);
                }
                else
                {
                charOccurrences[currentChar]++;
                }
            }
            foreach (KeyValuePair<Char,int> pair in charOccurrences)
            {
                char currentChar = pair.Key;
                int occurrences = pair.Value;
                Console.WriteLine($"{currentChar} -> {occurrences}");
            }
        }
    }
}
