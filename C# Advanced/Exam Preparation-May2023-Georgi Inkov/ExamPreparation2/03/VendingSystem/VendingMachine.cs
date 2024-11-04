using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace VendingSystem
{
    public class VendingMachine
    {
        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity > GetCount)
                Drinks.Add(drink);
        }
        public bool RemoveDrink(string name)
        {
            Drink drinkToRemove = Drinks.Find(drink => drink.Name == name);
            if (drinkToRemove != null)
            {
                Drinks.Remove(drinkToRemove);
                return true;
            }
            return false;
        }
        public Drink GetLongest()
        {
            if (Drinks.Count == 0)
            {
                return null;
            }

            Drink longestDrink = Drinks[0];
            foreach (Drink drink in Drinks)
            {
                if (drink.Volume > longestDrink.Volume)
                {
                    longestDrink = drink;
                }
            }
            return longestDrink;
        }
        public Drink GetCheapest()
        {
            if (Drinks.Count == 0)
            {
                return null;
            }
            Drink lowestValue = Drinks[0];
            foreach (Drink drink in Drinks)
            {
                if (drink.Price < lowestValue.Price)
                {
                    lowestValue = drink;
                }
            }
            return lowestValue;
        }
        public string BuyDrink(string name)
        {
            Drink drinkToBuy = Drinks.Find(drink => drink.Name == name);
            if (drinkToBuy != null)
            {
                Drinks.Remove(drinkToBuy);
            }
            return drinkToBuy.ToString();
        }
        public string Report()
        {
            StringBuilder sb = new ();
            sb.AppendLine("Drinks available:");

            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
