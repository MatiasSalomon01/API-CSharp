using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        Task<ICollection<Country>> GetAll();
        Task<Country> GetById(int id);
        Task<bool> CreateCountry(Country country);
        Task<bool> UpdateCountry(Country country);
        Task<bool> DeleteCountry(int id);
        Task<bool> Save();
    }
}
