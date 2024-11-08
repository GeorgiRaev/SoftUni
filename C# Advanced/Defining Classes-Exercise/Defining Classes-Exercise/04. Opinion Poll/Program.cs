﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> peopleOver30 = new List<Person>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] personProperties = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new Person(personProperties[0] , int.Parse(personProperties[1]));

            if (person.Age > 30 )
            {
                peopleOver30.Add(person);
            }
        }
        
        foreach (var person in peopleOver30.OrderBy(p => p.Name).ToList())
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

