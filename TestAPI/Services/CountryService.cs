using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TestAPI.Interfaces.Repositories;
using TestAPI.Interfaces.Services;

namespace TestAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
