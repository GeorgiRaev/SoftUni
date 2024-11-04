using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string output = ProcessExplosions(input);
            Console.WriteLine(output);
        }
        // abv>1>1>2>2asdasd
        // peter>2sis>1a>2akarate>4hexmaster
        private static string ProcessExplosions(string input)
        {
            StringBuilder sb = new StringBuilder();
            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                    sb.Append(input[i]);
                }
                else if (strength == 0)
                {
                    sb.Append(input[i]);
                }
                else 
                {
                    strength--;
                }
            }
            return sb.ToString();
        }
    }
}
