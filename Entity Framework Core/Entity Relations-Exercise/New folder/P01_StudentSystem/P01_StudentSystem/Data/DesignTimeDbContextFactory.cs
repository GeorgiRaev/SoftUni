using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace P01_StudentSystem.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentSystemContext>
    {
        public StudentSystemContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentSystemContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NewStudentSystem;Trusted_Connection=True;");

            return new StudentSystemContext(optionsBuilder.Options);
        }
    }
}

 