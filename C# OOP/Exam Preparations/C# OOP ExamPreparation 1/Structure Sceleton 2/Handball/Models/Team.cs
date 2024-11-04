using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        public Team(string name)
        {
            Name = name;
            players = new List<IPlayer>();
        }
        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team name cannot be null or empty.");
                }
                name = value;
            }
        }

        private int pointsEarned;

        public int PointsEarned
        {
            get { return pointsEarned; }
            private set { pointsEarned = value; }
        }


        public double OverallRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return Math.Round(players.Average(p => p.Rating),2);
            }
        }

        private List<IPlayer> players;

        public IReadOnlyCollection<IPlayer> Players
        {
            get { return players.AsReadOnly(); }
        }

        public void Draw()
        {
            PointsEarned += 1;
            IPlayer goalkeeper = players.FirstOrDefault(p => p is Goalkeeper);
            if (goalkeeper != null)
            {
                goalkeeper.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }
        public override string ToString()
        {
            string playerToString = "none";
            if (players.Count > 0)
            {
                playerToString = String.Join(", ", players.Select(p => p.Name));
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.AppendLine($"--Players: {playerToString}");
            return sb.ToString().TrimEnd();
        }
    }
}
