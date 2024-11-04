using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Catalog catalog = new Catalog();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split("/");

                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];

                if (type == "Car")
                {
                    catalog.Cars.Add(new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = int.Parse(tokens[3])
                    });
                }
                else // truck
                {
                    catalog.Trucks.Add(new Truck
                    {
                        Model = model,
                        Brand = brand,
                        Weight = int.Parse(tokens[3])
                    });
                }
            }

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                // one way of doing it.
                foreach (Car car in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                // another way of doing it.
                catalog.Trucks.OrderBy(x => x.Brand);
                foreach (Truck truck in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
    public class Catalog
    {
        // Initializes empty lists of trucks and cars
        // If you don't initialize the Trucks and Cars collections in the Catalog class, they will have a default value of null. This means that if you try to access or modify these collections before initializing them, you will encounter a NullReferenceException error.
        public Catalog()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }

        // List property to store trucks
        public List<Truck> Trucks { get; set; }

        // List property to store cars
        public List<Car> Cars { get; set; }
    }
    public class Truck
    {
        // The brand of the truck
        public string Brand { get; set; }

        // The model of the truck
        public string Model { get; set; }

        // The weight of the truck in kilograms
        public int Weight { get; set; }
    }
    public class Car
    {
        // The brand of the car
        public string Brand { get; set; }

        // The model of the car
        public string Model { get; set; }

        // The horsepower of the car
        public int HorsePower { get; set; }
    }
}
