using Microsoft.EntityFrameworkCore;

namespace F1_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
        public DbSet<Archive1950_2023> Archive { get; set; }
        public DbSet<Schedule2024> Schedule2024 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфигуриране на връзката между Driver и Team
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Team)
                .WithMany(t => t.Drivers)
                .HasForeignKey(d => d.TeamId);

            // Конфигуриране на връзката между RaceResult и Driver
            modelBuilder.Entity<RaceResult>()
                .HasOne(rr => rr.Driver)
                .WithMany(d => d.RaceResults)
                .HasForeignKey(rr => rr.DriverId);
        }
    }
}
