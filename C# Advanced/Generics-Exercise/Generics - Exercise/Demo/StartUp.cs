using System;
using System.Collections.Generic;
using System.Linq;
public class StartUp
{
    public static void Main()
    {
        var machine = new VendingMachine(5);

        var cola = new Drink("Cola", 1.2m, 500);
        var fanta = new Drink("Fanta", 1.3m, 450);
        var water = new Drink("Water", 0.7m, 500);
        var coffee = new Drink("Coffee", 1.0m, 30);

        machine.AddDrink(cola);
        machine.AddDrink(fanta);
        machine.AddDrink(water);
        machine.AddDrink(coffee);

        Console.WriteLine(machine.GetLongest());
        Console.WriteLine(machine.GetCheapest());
        Console.WriteLine(machine.BuyDrink("Water"));

        Console.WriteLine(machine.Report());
    }
}