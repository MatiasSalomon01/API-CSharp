using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<ICollection<City>> GetAll();
    }
}
