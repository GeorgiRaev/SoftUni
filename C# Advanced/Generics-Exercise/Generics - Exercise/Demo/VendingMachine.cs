using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class VendingMachine
    {
        private List<Drink> drinks;

        public int ButtonCapacity { get; private set; }
        public int GetCount => drinks.Count;

        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            drinks = new List<Drink>();
        }

        public void AddDrink(Drink drink)
        {
            if (drinks.Count < ButtonCapacity)
            {
                drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            Drink drink = drinks.FirstOrDefault(d => d.Name == name);
            if (drink != null)
            {
                drinks.Remove(drink);
                return true;
            }
            return false;
        }

        public Drink GetLongest()
        {
            return drinks.OrderByDescending(d => d.Volume).FirstOrDefault();
        }

        public Drink GetCheapest()
        {
            return drinks.OrderBy(d => d.Price).FirstOrDefault();
        }

        public string BuyDrink(string name)
        {
            Drink drink = drinks.FirstOrDefault(d => d.Name == name);
            if (drink != null)
            {
                drinks.Remove(drink);
                return drink.ToString();
            }
            return $"Can't find drink {name}";
        }

        public string Report()
        {
            return "Drinks available:\n" + string.Join("\n", drinks.Select(d => d.ToString()));
        }
    }
}
