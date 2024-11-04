using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(@|#)([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";

            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> mirrorWords = new List<string>();

            foreach (Match match in matches)
            {
                string wordOne = match.Groups[2].Value;
                string wordTwo = match.Groups[3].Value;
                string reversedWordOne = ReverseString(wordOne);

                if (reversedWordOne == wordTwo)
                {
                    mirrorWords.Add($"{wordOne} <=> {wordTwo}");
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }

        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
