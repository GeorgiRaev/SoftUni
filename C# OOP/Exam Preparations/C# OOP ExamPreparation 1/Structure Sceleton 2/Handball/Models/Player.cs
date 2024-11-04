using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty.");
                }
                name = value;
            }
        }

        private double rating;

        public double Rating
        {
            get { return rating; }
            protected set
            {
                if (value > 10)
                {
                    rating = 10;
                    return;
                }
                else if (value < 1)
                {
                    rating = 1;
                    return;
                }
                rating = value;

            }
        }

        private string team;

        public string Team
        {
            get { return team; }
        }

        public abstract void DecreaseRating();

        public abstract void IncreaseRating();

        public void JoinTeam(string name)
        {
            team = name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}: {Name}");
            sb.Append($"--Rating: {Rating}");
            return sb.ToString().TrimEnd();
        }
    }
}
