using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ").ToArray();

            foreach (string userName in userNames)
            {
                if (userName.Length < 3 || userName.Length > 16)
                {
                    continue;
                }
                bool isValidName = userName.All(character => char.IsLetterOrDigit(character) || character == '-' || character == '_');

                if (isValidName)
                {
                    Console.WriteLine(userName);
                }
            }
        }
    }
}
