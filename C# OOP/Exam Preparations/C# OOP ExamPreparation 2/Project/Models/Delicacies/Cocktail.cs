using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Cocktail : ICocktail
    {
        protected Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
            
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }


        private string size;

        public string Size
        {
            get { return size; }
            private set { size = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            private set
            {
                if (this.Size == "Small")
                {
                    price = value / 3;
                }
                else if (this.Size == "Middle")
                {
                    price = (value / 3) * 2;
                }
                else
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }

    }
}
