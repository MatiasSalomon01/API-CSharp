using Microsoft.AspNetCore.Mvc;
using TestAPI.Interfaces.Services;
using TestAPI.Models;
using TestAPI.Models.DTO.City;

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService _services;

        public CityController(ICityService services)
        {
            _services = services;
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAll());
        }

        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _services.GetById(id);

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
        public async Task<IActionResult> CreateCity([FromBody] CityCreateDTO city)
        {
            var result = await _services.CreateCity(city);
            if (0.Equals(result.Status))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCity(CityUpdateDTO city)
        {
            var result = await _services.UpdateCity(city);
            if (0.Equals(result.Status))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var result = await _services.DeleteCity(id);
            if (0.Equals(result.Status))
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
