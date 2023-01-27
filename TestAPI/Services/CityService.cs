using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TestAPI.Interfaces.Repositories;
using TestAPI.Interfaces.Services;
using TestAPI.Models;
using TestAPI.Models.DTO.City;
using TestAPI.Repositories;

namespace TestAPI.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<City>> GetAll()
        {
            return await _cityRepository.GetAll();
        }

        public async Task<City> GetById(int id)
        {
            return await _cityRepository.GetById(id);
        }

        public async Task<Response> CreateCity(CityCreateDTO city)
        {
            return await _cityRepository.CreateCity(_mapper.Map<City>(city));
        }

        public async Task<Response> UpdateCity(CityUpdateDTO city)
        {
            return await _cityRepository.UpdateCity(_mapper.Map<City>(city));
        }

        public async Task<Response> DeleteCity(int id)
        {
            return await _cityRepository.DeleteCity(id);
        }
    }
}
