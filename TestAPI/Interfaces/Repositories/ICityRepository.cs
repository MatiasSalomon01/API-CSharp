using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<ICollection<City>> GetAll();
        Task<City> GetById(int id);
        Task<Response> CreateCity(City city);
        Task<Response> UpdateCity(City city);
        Task<Response> DeleteCity(int id);
        Task<bool> Save();
    }
}
