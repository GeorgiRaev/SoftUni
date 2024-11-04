using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P02_FootballBettingSystem.Models;

namespace P02_FootballBetting.Data
{
    
    public class FootballBettingContext : DbContext
    {
        private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NewStudentSystem;Trusted_Connection=True;";

        public DbSet<Country> Countries { get; set; }

        public FootballBettingContext(DbContextOptions dco) : base(dco) {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
    
}
