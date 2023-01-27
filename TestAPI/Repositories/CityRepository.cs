using AutoMapper;
using EFCore.BulkExtensions;
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
        private readonly IMapper _mapper;


        public CityRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<Response> CreateCity(City city)
        {
            var countryId = await _context.Country.FindAsync(city.CountryId);
            if (countryId == null)
            {
                return new Response(1, "Unable to Create City", DateTime.Now);
            }
            else
            {
                await _context.City.AddAsync(city);
                await Save();
                return new Response(0, "City Updated Successfully", DateTime.Now);
            }
        }

        public async Task<Response> UpdateCity(City city)
        {
            if (_context.City.Any(c => c.Id == city.Id && c.CountryId == city.CountryId))
            {
               _context.City.Update(city);
                await Save();
                return new Response(0, "City Updated Successfully", DateTime.Now);
            } 
            else
            {
                return new Response(1, "Unable to Update City", DateTime.Now);
            }
        }

        public async Task<Response> DeleteCity(int id)
        {
            var result = await _context.City.FindAsync(id);
            if (result != null)
            {
                _context.City.Remove(result);
                await Save();
                return new Response(0, "City Deleted Successfully", DateTime.Now);
            }
            else
            {
                return new Response(1, "Unable to Delete City", DateTime.Now);
            }
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
