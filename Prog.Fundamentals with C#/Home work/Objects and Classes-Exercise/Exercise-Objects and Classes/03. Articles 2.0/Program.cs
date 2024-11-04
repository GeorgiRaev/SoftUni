﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] articleArguments = Console.ReadLine()
                    .Split(", ");
                string title = articleArguments[0];
                string content = articleArguments[1];
                string author = articleArguments[2];
                Article article = new Article(title, content, author);
                articles.Add(article);

            }
            Console.WriteLine(string.Join("\n",articles));
        }
    }
}
