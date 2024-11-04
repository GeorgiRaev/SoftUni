using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        public DelicacyRepository()
        {
            Models = new List<IDelicacy>();
        }
        private IReadOnlyCollection<IDelicacy> models;

        public IReadOnlyCollection<IDelicacy> Models
        {
            get { return models; }
            private set { models = value; }
        }


        public void AddModel(IDelicacy model)
        {
            throw new NotImplementedException();
        }
    }
}
