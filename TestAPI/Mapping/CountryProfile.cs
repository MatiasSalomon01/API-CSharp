using AutoMapper;
using TestAPI.Models;
using TestAPI.Models.DTO;

namespace TestAPI.Mapping
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDTO>();
        }
    }
}
