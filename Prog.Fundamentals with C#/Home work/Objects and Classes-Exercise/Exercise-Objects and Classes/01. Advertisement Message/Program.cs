using System;
using System.Collections.Generic;

namespace _01._Advertisement_Message
{
    class Advertisement
    {
        private static void Main()
        {
            string[] phrases = {"Excellent product.", "Such a great product.",
                "I always use that product.", "Best product of its category.", "Exceptional product.",
                "I can't live without this product."};

            string[] events = {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. " +
                    "I am happy of the results!","I cannot believe but now I feel awesome.","Try it yourself, " +
                    "I am very satisfied.", "I feel great!"};

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int messagesCount = int.Parse(Console.ReadLine());

            Random random = new Random();


            for (int i = 0; i < messagesCount; i++)
            {
                string randomPhrase = phrases[random.Next(phrases.Length)];
                string randomEvent = events[random.Next(events.Length)];
                string randomAuthor = authors[random.Next(authors.Length)];
                string randomCity = cities[random.Next(cities.Length)];

                string massage = $"{randomPhrase}{randomEvent}{randomAuthor}{randomCity}";
                Console.WriteLine(massage);
            }
        }
    }
}
