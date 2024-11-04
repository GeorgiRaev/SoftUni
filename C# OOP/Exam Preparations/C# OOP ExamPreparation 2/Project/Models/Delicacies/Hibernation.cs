using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Hibernation : Cocktail
    {
        private const double largePrice = 10.50;
        public Hibernation(string cocktailName, string size) : base(cocktailName, size, largePrice)
        {
        }
    }
}
