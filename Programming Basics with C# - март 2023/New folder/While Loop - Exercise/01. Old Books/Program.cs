using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            int count = 0;
            string input = string.Empty;
            while (input != "No More Books")
            {
                input = Console.ReadLine();
                if (input == favoriteBook)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
                if (input != "No More Books")
                {
                    count++;
                }
            }
            if (input == "No More Books")
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
        }
    }
}
