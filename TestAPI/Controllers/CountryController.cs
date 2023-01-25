using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Country.ToListAsync());
        }

        [HttpGet("get-{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _context.Country.FindAsync(id);
            return Ok(country);
        }

        [HttpPost("create-country")]
        public async Task<IActionResult> CreateCountry([FromBody] Country country)
        {
            var result = await _context.Country.AddAsync(country);
            await _context.SaveChangesAsync();
            return Ok(new Response(0, "Country Created Successfully", DateTime.Now));
        }

        [HttpPut("put-country")]
        public async Task<IActionResult> UpdateCountry(Country country)
        {
            _context.Country.Update(country);
            await _context.SaveChangesAsync();
            return Ok(new Response(0, "Country Updated Successfully", DateTime.Now));
        }

        [HttpDelete("delete-country")]
        public async Task<IActionResult> DeleteCountry([FromBody] int id)
        {
            var result = await _context.Country.FindAsync(id);
            if (result != null)
            {
                _context.Country.Remove(result);
                await _context.SaveChangesAsync();
                return Ok(new Response(0, "Country Deleted Successfully", DateTime.Now));
            }
            else
            {
                return NotFound(new Response(1, "Unable to Delete Country", DateTime.Now));
            }
        }
    }
}
