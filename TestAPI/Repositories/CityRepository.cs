using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
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

        public async Task<City> GetById(int id)
        {
            var city = await _context.City.Where(c => c.Id == id).FirstOrDefaultAsync();
            return city;
        }

        public async Task<bool> CreateCity(City city)
        {
            var countryId = await _context.Country.FindAsync(city.CountryId);
            if (countryId == null)
            {
                return false;
            }
            else
            {
                await _context.City.AddAsync(city);
                return await Save();
            }
        }

        public async Task<bool> UpdateCity(City city)
        {
            _context.City.Update(city);
            return await Save();
        }

        public async Task<bool> DeleteCity(int id)
        {
            var result = await _context.City.FindAsync(id);
            if (result != null)
            {
                _context.City.Remove(result);
                return await Save();
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
