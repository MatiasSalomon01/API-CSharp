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
    }
}
