using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        //public DbSet<StudentCourse> Student_Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

    
}
