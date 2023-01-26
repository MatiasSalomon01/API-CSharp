using AutoMapper;
using TestAPI.Models.DTO;
using TestAPI.Models;

namespace TestAPI.Mapping
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>();
        }
    }
}
