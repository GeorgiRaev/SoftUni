using System;
using System.Collections.Generic;

namespace DecryptingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            List<string> outputs = new List<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Finish")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Replace")
                {
                    string currentChar = tokens[1];
                    string newChar = tokens[2];
                    message = message.Replace(currentChar, newChar);
                    outputs.Add(message);
                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (IsValidIndex(startIndex, message.Length) && IsValidIndex(endIndex, message.Length))
                    {
                        message = message.Remove(startIndex, endIndex - startIndex + 1);
                        outputs.Add(message);
                    }
                    else
                    {
                        outputs.Add("Invalid indices!");
                    }
                }
                else if (action == "Make")
                {
                    string caseType = tokens[1];
                    if (caseType == "Upper")
                    {
                        message = message.ToUpper();
                        outputs.Add(message);
                    }
                    else if (caseType == "Lower")
                    {
                        message = message.ToLower();
                        outputs.Add(message);
                    }
                }
                else if (action == "Check")
                {
                    string checkString = tokens[1];
                    if (message.Contains(checkString))
                    {
                        outputs.Add($"Message contains {checkString}");
                    }
                    else
                    {
                        outputs.Add($"Message doesn't contain {checkString}");
                    }
                }
                else if (action == "Sum")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (IsValidIndex(startIndex, message.Length) && IsValidIndex(endIndex, message.Length))
                    {
                        int sum = 0;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += message[i];
                        }
                        outputs.Add(sum.ToString());
                    }
                    else
                    {
                        outputs.Add("Invalid indices!");
                    }
                }
            }

            foreach (string output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        private static bool IsValidIndex(int index, int length)
        {
            return index >= 0 && index < length;
        }
    }
}
