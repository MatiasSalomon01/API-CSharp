using Microsoft.AspNetCore.Mvc;
using TestAPI.Interfaces.Services;
using TestAPI.Models;
using TestAPI.Models.DTO.Country;

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _services;
        public StudentController(IStudentService services)
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
                return NotFound(new Response(1, "Unable to Retrieve Student " + id, DateTime.Now));
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCountry([FromBody] Student student)
        {
            var result = await _services.CreateStudent(student);
            if (0.Equals(result.Status))
            {
                return Ok(new Response(0, "Student Created Successfully", DateTime.Now));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            var result = await _services.UpdateStudent(student);
            if (0.Equals(result.Status))
            {
                return Ok(new Response(0, "Student Updated Successfully", DateTime.Now));
            }
            else
            {
                return NotFound(new Response(1, "Student Not Found", DateTime.Now));
            }
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _services.DeleteStudent(id);
            if (0.Equals(result.Status))
            {
                return Ok(new Response(0, "Student Deleted Successfully", DateTime.Now));
            }
            else
            {
                return NotFound(new Response(1, "Unable to Delete Student", DateTime.Now));
            }
        }
    }
}
