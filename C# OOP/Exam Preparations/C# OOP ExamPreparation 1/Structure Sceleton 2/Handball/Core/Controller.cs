using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        private PlayerRepository players;
        private TeamRepository teams;
        private string[] validPlayersType = { "Goalkeeper", "CenterBack", "ForwardWing" };

        

        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return String.Format(OutputMessages.PlayerNotExisting, playerName,typeof(PlayerRepository).Name);
            }
            if (!teams.ExistsModel(teamName))
            {
                return String.Format(OutputMessages.TeamNotExisting, teamName, typeof(TeamRepository).Name);
            }

            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);

            if (player.Team != null)
            {
                return String.Format(OutputMessages.PlayerAlreadySignedContract,playerName,player.Team);
            }
            player.JoinTeam(team.Name);
            team.SignContract(player);

            return String.Format(OutputMessages.SignContract, playerName, teamName);

        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            ITeam winningTeam = null;
            ITeam loosingTeam = null;
            bool isDrow = false;
            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                winningTeam = firstTeam;
                loosingTeam=secondTeam;
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                winningTeam = secondTeam;
                loosingTeam = firstTeam;
            }
            else
            {
                isDrow = true;
            }
            if (!isDrow)
            {
                winningTeam.Win();
                loosingTeam.Lose();
                return String.Format(OutputMessages.GameHasWinner, winningTeam.Name, loosingTeam.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return String.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
            }
        }

        public string NewPlayer(string typeName, string name)
        {
            if (!validPlayersType.Contains(typeName))
            {
                return String.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }
            if (players.ExistsModel(name))
            {
                IPlayer existingPlayer = players.GetModel(name);
                return String.Format(OutputMessages.PlayerAlreadyExists, name, typeof(PlayerRepository).Name);
            }
            IPlayer newPlayer = null;

            if(typeName == "Goalkeeper")
            {
                newPlayer = new Goalkeeper(name);
            }
            if (typeName == "CenterBack")
            {
                newPlayer = new CenterBack(name);
            }
            if (typeName == "ForwardWing")
            {
                newPlayer = new ForwardWing(name);
            }

            players.AddModel(newPlayer);

            return String.Format(OutputMessages.PlayerAddedSuccessfully, name);

        }

        public string NewTeam(string name)
        {
            Team team = new Team(name);
            if (teams.ExistsModel(name))
            {
                return String.Format(OutputMessages.PlayerAlreadyExists, name, typeof(TeamRepository).Name);
            }

            teams.AddModel(team);

            return String.Format(OutputMessages.TeamSuccessfullyAdded, name, typeof(TeamRepository).Name);
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = teams.GetModel(teamName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");

            List<IPlayer> sortedPlayers = team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name).ToList();

            foreach (IPlayer player in sortedPlayers)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***League Standings***");

            List<ITeam> sortedTeams = teams.Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name).ToList();

            foreach (IPlayer team in sortedTeams)
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
