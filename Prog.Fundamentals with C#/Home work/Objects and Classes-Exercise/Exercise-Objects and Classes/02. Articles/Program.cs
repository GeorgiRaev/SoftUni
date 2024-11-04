using System;
using System.Linq;

namespace _02._Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public void Edit(string NewContent)
        {
            Content = NewContent;
        }
        public void ChangeAuthor(string newArthor)
        {
            Author = newArthor;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();
            string title = input[0];
            string content = input[1];
            string author = input[2];
            Article article = new Article(title, content, author);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandData = Console.ReadLine()
                    .Split(": ")
                    .ToArray();
                string command = commandData[0];
                string argument = commandData[1];

                if (command == "Edit")
                {
                    article.Edit(argument);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(argument);
                }
                else if (command == "Rename")
                {
                    article.Rename(argument);
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
            Console.WriteLine(article);
        }
    }
}
