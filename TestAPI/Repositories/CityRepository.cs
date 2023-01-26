using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Interfaces.Repositories;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<City>> GetAll()
        {
            return await _context.City.OrderBy(c => c.Id).ToListAsync();
        }
    }
}
