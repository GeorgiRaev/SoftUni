/*
zzHe
ChangeAll|z|l
Insert|2|o
Move|3
Decode

 */
using System;

namespace _04.The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command;

            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] inputArr = command.Split("|");
                command = inputArr[0];

                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(inputArr[1]);
                    string temp = input.Substring(0, numberOfLetters);
                    input = input.Remove(0, numberOfLetters);
                    input = input + temp;

                }
                else if (command == "Insert")
                {
                    int index = int.Parse(inputArr[1]);
                    string value = inputArr[2];
                    input = input.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = inputArr[1];
                    string replacement = inputArr[2];
                    input = input.Replace(substring, replacement);
                }
            }
            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}
