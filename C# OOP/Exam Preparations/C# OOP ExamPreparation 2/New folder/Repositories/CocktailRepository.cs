﻿using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }
        private List<ICocktail> models;

        public IReadOnlyCollection<ICocktail> Models
        {
            get { return models; }
        }


        public void AddModel(ICocktail model)
        {
            throw new NotImplementedException();
        }
    }
}
