using TestAPI.Models;
using TestAPI.Models.DTO.City;

namespace TestAPI.Interfaces.Services
{
    public interface ICityService
    {
        Task<ICollection<CityGetAllDTO>> GetAll();
        Task<CityGetAllDTO> GetById(int id);
        Task<Response> CreateCity(CityCreateDTO city);
        Task<Response> UpdateCity(CityUpdateDTO city);
        Task<Response> DeleteCity(int id);
    }
}
