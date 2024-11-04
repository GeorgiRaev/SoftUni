using System;

class Program
{
    static void Main()
    {
        string secretMessege = Console.ReadLine();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Reveal")
            {
                break;
            }

            string[] commands = input.Split(":|:");
            string action = commands[0];

            if (action == "InsertSpace")
            {
                int index = int.Parse(commands[1]);
                secretMessege = secretMessege.Insert(index, " ");
                Console.WriteLine(secretMessege);
            }
            else if (action == "Reverse")
            {
                string substring = commands[1];

                if (secretMessege.Contains(substring))
                {
                    int index = secretMessege.IndexOf(substring);
                    secretMessege = secretMessege.Remove(index, substring.Length);
                    string reversedSubstring = ReverseString(substring);
                    secretMessege = secretMessege + reversedSubstring;
                    Console.WriteLine(secretMessege);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (action == "ChangeAll")
            {
                string substring = commands[1];
                string replacement = commands[2];
                secretMessege = secretMessege.Replace(substring, replacement);
                Console.WriteLine(secretMessege);
            }
        }

        Console.WriteLine($"You have a new text message: {secretMessege}");
    }

    static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
