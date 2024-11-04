using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            Booth newBooth = new Booth(boothId, capacity);
            booths.AddModel(newBooth);
            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth boothToFind = null;
            foreach (var booth in booths.Models)
            {
                if (booth.BoothId == boothId)
                {
                    boothToFind = booth;
                }
            }

            ICocktail cocktail = null;

            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);

            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
               
            }
            else
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if (size != "Small" && size!= "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            foreach (var currentCocktail in boothToFind.CocktailMenu.Models)
            {
                if (currentCocktail.Name == cocktailName && currentCocktail.Size == size)
                {
                    return $"{size} {cocktailName} is already added in the pastry shop!";
                }
            }

            boothToFind.CocktailMenu.AddModel(cocktail);
            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth boothToAdd = null;
            foreach (var booth in booths.Models)
            {
                if (booth.BoothId == boothId)
                {
                    boothToAdd = booth;
                }
            }

            IDelicacy delicacyToAdd;

            if (delicacyTypeName == "Gingerbread")
            {
                delicacyToAdd = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacyToAdd = new Stolen(delicacyName);
            }
            else
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }
            foreach (var delicacy in boothToAdd.DelicacyMenu.Models)
            {
                if (delicacy.Name == delicacyToAdd.Name)
                {
                    return $"{delicacyName} is already added in the pastry shop!";
                }
            }
            boothToAdd.DelicacyMenu.AddModel(delicacyToAdd);
            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> freeBooths = booths.Models
                .Where(x => !x.IsReserved && x.Capacity >= countOfPeople)
                .OrderBy(x=>x.Capacity)
                .OrderByDescending(x=>x.BoothId).ToList();
            IBooth booth = freeBooths.FirstOrDefault();
            if (booth != null)
            {
                booth.ChangeStatus();
                return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
            }
            else
            {
                return $"No available booth for {countOfPeople} people!";
            }

        }

        public string TryOrder(int boothId, string order)
        {
            throw new NotImplementedException();
        }
    }
}
