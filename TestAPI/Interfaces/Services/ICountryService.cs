using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Models.DTO.Country;

namespace TestAPI.Interfaces.Services
{
    public interface ICountryService
    {
        Task<ICollection<Country>> GetAll();

        Task<Country> GetById(int id);

        Task<bool> CreateCountry(CountryCreateDTO country);
        Task<bool> UpdateCountry(CountryUpdateDTO country);
        Task<bool> DeleteCountry(int id);
    }
}
