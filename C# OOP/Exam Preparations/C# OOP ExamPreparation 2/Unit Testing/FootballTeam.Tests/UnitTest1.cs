using NUnit.Framework;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Contructor()
        {
            var team = new FootballTeam("cska", 20);

            Assert.AreEqual(team.Name, "cska");
            Assert.AreEqual(team.Capacity, 20);
            Assert.AreEqual(team.Players.Count, 0);
        }

        [Test]
        public void Test_If_Name_Is_Null_Or_Empty()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 20));
            Assert.Throws<ArgumentException>(() => new FootballTeam(string.Empty, 20));
        }

        [Test]
        public void Test_If_CapacityCount_Is_Correctly()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("cska", 14));
            Assert.Throws<ArgumentException>(() => new FootballTeam("cska", 0));
        }

        [Test]
        public void Test_AddNewPlayer_Throws_Exception()
        {
            var team = new FootballTeam("cska", 20);

            for (int i = 1; i <= 20; i++)
            {
                team.AddNewPlayer(new FootballPlayer($"Messi{i}", i, "Forward"));
            }
            var player = new FootballPlayer("Messii", 21, "Forward");
            var expectResult = team.AddNewPlayer(player);
            Assert.AreEqual(expectResult, "No more positions available!");
        }

        [Test]
        public void Test_Add_New_Ploayer_Correctly()
        {
            var team = new FootballTeam("cska", 15);
            var player = new FootballPlayer("Messi", 10, "Forward");
            var actualResult = team.AddNewPlayer(player);
            var expectedResult = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestPickPlayerWorkCorectly()
        {
            var team = new FootballTeam("cska", 15);
            var player = new FootballPlayer("Georgi", 1, "Goalkeeper");

            team.AddNewPlayer(player);

            Assert.AreEqual(team.PickPlayer("Georgi"), player);
            Assert.AreEqual(team.PickPlayer("Gosho"), null);

        }

        [Test]
        public void TestPlayerScoreGoal()
        {
            var team = new FootballTeam("cska", 20);
            var player = new FootballPlayer("Georgi", 10, "Forward");
            team.AddNewPlayer(player);

            var expected = team.PlayerScore(10);
            Assert.AreEqual(player.ScoredGoals, 1);
            Assert.AreEqual(expected, $"{player.Name} scored and now has 1 for this season!");


        }
    }
}