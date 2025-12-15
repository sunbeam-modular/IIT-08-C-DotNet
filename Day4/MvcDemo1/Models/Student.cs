using Microsoft.EntityFrameworkCore;

namespace MvcDemo1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
    }

    public class SbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=StudentDB3;Trusted_Connection=True;");
        }
    }
}
