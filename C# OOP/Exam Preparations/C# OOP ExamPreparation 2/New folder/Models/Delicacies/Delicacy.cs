using ChristmasPastryShop.Models.Delicacies.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {

        private string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

    }
}
