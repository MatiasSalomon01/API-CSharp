using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<ICollection<City>> GetAll();
        Task<City> GetById(int id);
        Task<bool> CreateCity(City city);
        Task<bool> UpdateCity(City city);
        Task<bool> DeleteCity(int id);
        Task<bool> Save();
    }
}
