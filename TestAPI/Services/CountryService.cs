using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TestAPI.Interfaces.Repositories;
using TestAPI.Interfaces.Services;
using TestAPI.Models;
using AutoMapper;
using System.Diagnostics.Metrics;
using TestAPI.Models.DTO.Country;

namespace TestAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Country>> GetAll()
        {
            return await _countryRepository.GetAll();
        }

        public async Task<Country> GetById(int id)
        {
            return await _countryRepository.GetById(id);
        }

        public async Task<bool> CreateCountry(CountryCreateDTO country)
        {
            return await _countryRepository.CreateCountry(_mapper.Map<Country>(country));
        }

        public async Task<bool> UpdateCountry(CountryUpdateDTO country)
        {
            return await _countryRepository.UpdateCountry(_mapper.Map<Country>(country));
        }

        public async Task<bool> DeleteCountry(int id)
        {
            return await _countryRepository.DeleteCountry(id);

        }
    }
}
