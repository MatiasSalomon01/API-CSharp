using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Interfaces.Repositories;
using TestAPI.Models;
using TestAPI.Models.DTO;

namespace TestAPI.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<Country>> GetAll()
        {
            return await _context.Country.Include(c => c.Cities).OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Country> GetById(int id)
        {
            var country = await _context.Country.Where(c => c.Id == id).Include(c => c.Cities).FirstOrDefaultAsync();
            return country; 
        }

        public async Task<bool> CreateCountry(Country country)
        {
            await _context.Country.AddAsync(country);
            return await Save();
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            _context.Country.Update(country);
            return await Save();
        }

        public async Task<bool> DeleteCountry(int id)
        {
            var result = await _context.Country.FindAsync(id);
            if (result != null)
            {
                _context.Country.Remove(result);
                return await Save();
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Save()
        {
            var saved =await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
