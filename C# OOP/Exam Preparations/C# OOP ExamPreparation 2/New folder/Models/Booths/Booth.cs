using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        public Booth()
        {
            CocktailMenu = new CocktailRepository();
            DelicacyMenu = new DelicacyRepository();
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
            private set { capacity = value; }
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
            private set { currentBill = value; }
        }


        private double turnover;

        public double Turnover
        {
            get { return turnover; }
            private set { turnover = value; }
        }


        private bool isReserved;

        public bool IsReserved
        {
            get { return isReserved; }
            private set { isReserved = value; }
        }


        public void ChangeStatus()
        {
            throw new NotImplementedException();
        }

        public void Charge()
        {
            throw new NotImplementedException();
        }

        public void UpdateCurrentBill(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
