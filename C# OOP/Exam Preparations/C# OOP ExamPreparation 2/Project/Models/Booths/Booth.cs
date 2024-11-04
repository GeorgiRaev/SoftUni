using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        public Booth(int boothId,int capacity)
        {
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.CocktailMenu = new CocktailRepository();
            this.DelicacyMenu = new DelicacyRepository();

        }
        private int boothId;

        public int BoothId
        {
            get { return boothId; }
            private set { boothId = value; }
        }


        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }
                capacity = value;

            }
        }


        private IRepository<IDelicacy> delicacyMenu;

        public IRepository<IDelicacy> DelicacyMenu
        {
            get { return delicacyMenu; }
            private set { delicacyMenu = value; }
        }

        private IRepository<ICocktail> cocktailMenu;

        public IRepository<ICocktail> CocktailMenu
        {
            get { return cocktailMenu; }
            private set { cocktailMenu = value; }
        }



        private double currentBill;

        public double CurrentBill
        {
            get { return currentBill; }
            set { currentBill = value; }
        }


        private double turnover;

        public double Turnover
        {
            get { return turnover; }
            set
            {
                turnover = value;
            }
        }

        private bool isReserved;

        public bool IsReserved
        {
            get { return isReserved; }
            set { isReserved = value; }
        }


        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public void Charge()
        {

            this.Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var item in CocktailMenu.Models)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("-Delicacy menu:");

            foreach (var item in DelicacyMenu.Models)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
