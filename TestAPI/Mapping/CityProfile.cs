using AutoMapper;
using TestAPI.Models;
using TestAPI.Models.DTO.City;

namespace TestAPI.Mapping
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityCreateDTO, City>();
            CreateMap<CityUpdateDTO, City>();
        }
    }
}
