using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Course.Include(c => c.Student).OrderBy(c => c.Id).ToListAsync());
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
