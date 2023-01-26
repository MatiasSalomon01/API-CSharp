using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Interfaces.Services
{
    public interface ICountryService
    {
        Task<IActionResult> GetAll();

        Task<IActionResult> GetById(int id);
    }
}
