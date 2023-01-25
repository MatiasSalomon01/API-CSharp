using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.City.ToListAsync());
        }

        [HttpPost("create-city")]
        public async Task<IActionResult> CreateCity([FromBody] City city)
        {
            var result = await _context.City.AddAsync(city);
            await _context.SaveChangesAsync();
            return Ok(new Response(0, "City Created Successfully", DateTime.Now));
        }

        [HttpPut("update-city")]
        public async Task<IActionResult> UpdateCity(City city)
        {
            _context.City.Update(city);
            await _context.SaveChangesAsync();
            return Ok(new Response(0, "City Updated Successfully", DateTime.Now));
        }

        [HttpDelete("delete-city")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var result = await _context.City.FindAsync(id);
            if (result != null)
            {
                _context.City.Remove(result);
                await _context.SaveChangesAsync();
                return Ok(new Response(0, "City Deleted Successfully", DateTime.Now));
            }
            else
            {
                return NotFound(new Response(1, "Unable to Delete City", DateTime.Now));
            }
        }
    }
}
