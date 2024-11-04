using System;

public class StartUp
{
    public static void Main()
    {
        // Example usage:
        Coffee coffee = new Coffee("Espresso", 2.50M);
        Console.WriteLine(coffee);

        Fish fish = new Fish("Salmon", 12.50M);
        Console.WriteLine(fish);

        Cake cake = new Cake("Chocolate Cake", 4.50M);
        Console.WriteLine(cake);
    }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

public class Beverage : Product
{
    public double Milliliters { get; set; }

    public Beverage(string name, decimal price, double milliliters)
        : base(name, price)
    {
        Milliliters = milliliters;
    }
}

public class HotBeverage : Beverage
{
    public HotBeverage(string name, decimal price, double milliliters)
        : base(name, price, milliliters)
    {
    }
}

public class ColdBeverage : Beverage
{
    public ColdBeverage(string name, decimal price, double milliliters)
        : base(name, price, milliliters)
    {
    }
}

public class Coffee : HotBeverage
{
    public double CoffeeMilliliters { get; set; } = 50;
    public decimal CoffeePrice { get; set; } = 3.50M;
    public double Caffeine { get; set; }

    public Coffee(string name, decimal price)
        : base(name, price, 50)
    {
    }
}

public class Food : Product
{
    public double Grams { get; set; }

    public Food(string name, decimal price, double grams)
        : base(name, price)
    {
        Grams = grams;
    }
}

public class MainDish : Food
{
    public MainDish(string name, decimal price, double grams)
        : base(name, price, grams)
    {
    }
}

public class Dessert : Food
{
    public double Calories { get; set; }

    public Dessert(string name, decimal price, double grams, double calories)
        : base(name, price, grams)
    {
        Calories = calories;
    }
}

public class Starter : Food
{
    public Starter(string name, decimal price, double grams)
        : base(name, price, grams)
    {
    }
}

public class Fish : MainDish
{
    public Fish(string name, decimal price)
        : base(name, price, 22)
    {
    }
}

public class Soup : Starter
{
    public Soup(string name, decimal price, double grams)
        : base(name, price, grams)
    {
    }
}

public class Cake : Dessert
{
    public Cake(string name, decimal price)
        : base(name, price, 250, 1000)
    {
    }
}
