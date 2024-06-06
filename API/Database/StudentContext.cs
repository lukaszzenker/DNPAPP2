using DomainLibrary;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<GradeInCourse> Grades { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = DatabaseFile.db");
        }
    }
}
