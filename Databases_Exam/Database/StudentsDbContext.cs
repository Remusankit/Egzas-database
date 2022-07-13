using Microsoft.EntityFrameworkCore;

namespace Egzas_Databasu.Database
{
    public class StudentsDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=StudentsDb;Trusted_Connection=True;");
        }

    }
}
