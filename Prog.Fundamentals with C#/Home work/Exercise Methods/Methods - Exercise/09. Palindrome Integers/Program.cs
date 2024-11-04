using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numAsStr;
            while ((numAsStr = Console.ReadLine()) != "END")
            {
                Console.WriteLine(IsPalindrome(numAsStr));
            }
        }

        private static bool IsPalindrome(string numAsStr)
        {
            char[] arr = numAsStr.ToCharArray();
            Array.Reverse(arr);
            string temp = new string(arr);
            string second = new string(arr);

            return numAsStr == second;
        }
    }
}
