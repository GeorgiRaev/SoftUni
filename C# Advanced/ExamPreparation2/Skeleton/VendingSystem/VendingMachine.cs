using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }

        public int GetCount
        {
            get
            {
                return Drinks.Count;
            }
        }
        public void AddDrink(Drink drink)
        {
            if (GetCount < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }
        public bool RemoveDrink(string name)
        {
            Drinks.Remove(Drinks.FirstOrDefault(x => x.Name == name));
            return true;
        }
        public Drink GetLongest()
        {
            return Drinks.MaxBy(x => x.Volume);
        }
        public Drink GetCheapest()
        {
            return Drinks.MinBy(x => x.Price);
        }
        public string BuyDrink(string name) 
        {
            return Drinks.FirstOrDefault(x=>x.Name == name).ToString();
        }
        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("Drinks available:");
            foreach (Drink drink in Drinks) 
            {
                sb.AppendLine(drink.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
