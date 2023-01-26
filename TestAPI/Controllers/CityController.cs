using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TestAPI.Interfaces.Repositories;
using TestAPI.Models;
using TestAPI.Repositories;

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICityRepository _cityRepository;

        public CityController(ApplicationDbContext context, ICityRepository cityRepository)
        {
            _context = context;
            _cityRepository = cityRepository;
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cityRepository.GetAll());
        }

        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cityRepository.GetById(id);

            if (result == null)
            {
                return NotFound(new Response(1, "Unable to Retrieve City " + id, DateTime.Now));
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCity([FromBody] City city)
        {
            if (await _cityRepository.CreateCity(city))
            {
                return Ok(new Response(0, "City Created Successfully", DateTime.Now));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateCity(City city)
        {
            if (await _cityRepository.UpdateCity(city))
            {
                return Ok(new Response(0, "City Updated Successfully", DateTime.Now));
            }
            else
            {
                return NotFound(new Response(1, "City Not Found", DateTime.Now));
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var result = await _cityRepository.DeleteCity(id);
            if (result == true)
            {
                return Ok(new Response(0, "City Deleted Successfully", DateTime.Now));
            }
            else
            {
                return NotFound(new Response(1, "Unable to Delete City", DateTime.Now));
            }
        }
    }
}
