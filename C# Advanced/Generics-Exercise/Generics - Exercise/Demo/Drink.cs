﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Drink
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }

        public Drink(string name, decimal price, int volume)
        {
            Name = name;
            Price = price;
            Volume = volume;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: ${Price:F2}, Volume: {Volume} ml";
        }
    }
}
