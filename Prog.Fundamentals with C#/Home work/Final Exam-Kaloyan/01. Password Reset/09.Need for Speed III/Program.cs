using System;
using System.Collections.Generic;

class Car
{
    public string Name { get; set; }
    public int Mileage { get; set; }
    public int Fuel { get; set; }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] carData = Console.ReadLine().Split('|');
            string name = carData[0];
            int mileage = int.Parse(carData[1]);
            int fuel = int.Parse(carData[2]);
            cars.Add(new Car { Name = name, Mileage = mileage, Fuel = fuel });
        }

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Stop")
            {
                break;
            }

            string[] commands = input.Split(" : ");
            string action = commands[0];
            string carName = commands[1];

            if (action == "Drive")
            {
                int distance = int.Parse(commands[2]);
                int fuelNeeded = int.Parse(commands[3]);

                Car car = cars.Find(c => c.Name == carName);

                if (car.Fuel >= fuelNeeded)
                {
                    car.Mileage += distance;
                    car.Fuel -= fuelNeeded;
                    Console.WriteLine($"{carName} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");

                    if (car.Mileage >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {carName}!");
                        cars.Remove(car);
                    }
                }
                else
                {
                    Console.WriteLine("Not enough fuel to make that ride");
                }
            }
            else if (action == "Refuel")
            {
                int fuel = int.Parse(commands[2]);

                Car car = cars.Find(c => c.Name == carName);
                int availableSpace = 75 - car.Fuel;

                if (fuel <= availableSpace)
                {
                    car.Fuel += fuel;
                }
                else
                {
                    car.Fuel += availableSpace;
                }

                Console.WriteLine($"{carName} refueled with {car.Fuel} liters");
            }
            else if (action == "Revert")
            {
                int kilometers = int.Parse(commands[2]);

                Car car = cars.Find(c => c.Name == carName);
                car.Mileage -= kilometers;

                if (car.Mileage < 10000)
                {
                    car.Mileage = 10000;
                }

                Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
        }
    }
}
