﻿using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> models;

        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models 
        {
            get { return models; }
        }

        public void AddModel(IDelicacy model)
        {
            models.Add(model);
        }
    }
}
