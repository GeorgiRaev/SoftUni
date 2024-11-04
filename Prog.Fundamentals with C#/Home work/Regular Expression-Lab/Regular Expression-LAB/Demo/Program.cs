using System;
using System.Text.RegularExpressions;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "The car have black tyre.";
            string pattern = @"\bred\b"; // Шаблон за заместване

            string replacedText = Regex.Replace(text, pattern, "blue");

            Console.WriteLine(replacedText);
        }
    }
}
