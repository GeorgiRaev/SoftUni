using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    internal class Human
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public Human(string name, string id, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Human> list = new List<Human>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();

                string name = arguments[0];
                string id = arguments[1];
                int age = int.Parse(arguments[2]);

                Human human = new Human(name, id, age);
                if (arguments[1] != null)
                {
                    list.Add(human);
                }
                else
                {
                    list.Add(new Human(name, id, age));
                }
            }
            List<Human> orderedHuman = list.OrderBy(human => human.Age).ToList();

            foreach  (Human human in orderedHuman)
            {
                Console.WriteLine(human);
            }
        }
    }
}
