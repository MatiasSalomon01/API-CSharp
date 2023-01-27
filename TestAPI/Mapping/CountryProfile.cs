using AutoMapper;
using TestAPI.Models;
using TestAPI.Models.DTO.Country;

namespace TestAPI.Mapping
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryCreateDTO, Country>();
            CreateMap<CountryUpdateDTO, Country>();
        }
    }
}
