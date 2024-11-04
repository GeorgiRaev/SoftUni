using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
       
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
            private set { price = value; }
        }

    }
}
