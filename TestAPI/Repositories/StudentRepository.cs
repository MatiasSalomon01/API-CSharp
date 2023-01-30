using Microsoft.EntityFrameworkCore;
using TestAPI.Interfaces.Repositories;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;


        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Student>> GetAll()
        {
            return await _context.Student.OrderBy(s => s.Id).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            var student = await _context.Student.Where(c => c.Id == id).FirstOrDefaultAsync();
            return student;
        }
        public async Task<Response> CreateStudent(Student student)
        {
            await _context.Student.AddAsync(student);
            await Save();
            return new Response(0, "Student Updated Successfully", DateTime.Now);
        }
        public async Task<Response> UpdateStudent(Student student)
        {
            _context.Student.Update(student);
            await Save();
            return new Response(0, "City Student Successfully", DateTime.Now);

        }
        public async Task<Response> DeleteStudent(int id)
        {
            var result = await _context.Student.FindAsync(id);
            if (result != null)
            {
                _context.Student.Remove(result);
                await Save();
                return new Response(0, "Student Deleted Successfully", DateTime.Now);
            }
            else
            {
                return new Response(1, "Unable to Delete Student", DateTime.Now);
            }
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
