using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Interfaces.Repositories;
using TestAPI.Interfaces.Services;
using TestAPI.Models;
using TestAPI.Models.DTO.Country;

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _services;
        public CountryController(ICountryService services)
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
                return NotFound(new Response(1, "Unable to Retrieve Country "+id, DateTime.Now)); 
            }
            else
            { 
                return Ok(result); 
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCountry([FromBody] CountryCreateDTO country)
        {
            if (await _services.CreateCountry(country))
            {
                return Ok(new Response(0, "Country Created Successfully", DateTime.Now));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCountry(CountryUpdateDTO country)
        {
                if(await _services.UpdateCountry(country))
                {
                    return Ok(new Response(0, "Country Updated Successfully", DateTime.Now));
                }
                else
                {
                    return NotFound(new Response(1, "Country Not Found", DateTime.Now));
                }            
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var result = await _services.DeleteCountry(id);
            if (result == true)
            {
                return Ok(new Response(0, "Country Deleted Successfully", DateTime.Now));
            }
            else
            {
                return NotFound(new Response(1, "Unable to Delete Country", DateTime.Now));
            }
        }
    }
}
