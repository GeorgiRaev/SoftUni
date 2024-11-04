using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        while (true)
        {
            try
            {
                string type = Console.ReadLine();
                if (type == "Beast!")
                {
                    break;
                }

                string[] animalInfo = Console.ReadLine().Split();

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                Animal animal = CreateAnimal(type, name, age, gender);
                animals.Add(animal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static Animal CreateAnimal(string type, string name, int age, string gender)
    {
        switch (type)
        {
            case "Dog":
                return new Dog(name, age, gender);
            case "Cat":
                return new Cat(name, age, gender);
            case "Frog":
                return new Frog(name, age, gender);
            case "Kitten":
                return new Kitten(name, age);
            case "Tomcat":
                return new Tomcat(name, age);
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}

public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        return $"{GetType().Name}\n{Name} {Age} {Gender}\n{ProduceSound()}";
    }
}

public class Dog : Animal
{
    public Dog(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }
}

public class Cat : Animal
{
    public Cat(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Meow meow";
    }
}

public class Frog : Animal
{
    public Frog(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Ribbit";
    }
}

public class Kitten : Cat
{
    public Kitten(string name, int age)
        : base(name, age, "Female")
    {
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}

public class Tomcat : Cat
{
    public Tomcat(string name, int age)
        : base(name, age, "Male")
    {
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}
