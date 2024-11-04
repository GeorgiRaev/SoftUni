using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        public BoothRepository()
        {
            Models = new List<IBooth>();
        }

        private IReadOnlyCollection<IBooth> models;

        public IReadOnlyCollection<IBooth> Models
        {
            get { return models; }
            private set { models = value; }
        }


        public void AddModel(IBooth model)
        {
            throw new NotImplementedException();
        }
    }
}
