using Microsoft.EntityFrameworkCore;



namespace WebApplication1.Models
{
    class SbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=StudentDB2;Trusted_Connection=True;");
        }
    }
}