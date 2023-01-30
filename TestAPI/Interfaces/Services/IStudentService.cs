using TestAPI.Models.DTO.Country;
using TestAPI.Models;

namespace TestAPI.Interfaces.Services
{
    public interface IStudentService
    {
        Task<ICollection<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Response> CreateStudent(Student student);
        Task<Response> UpdateStudent(Student student);
        Task<Response> DeleteStudent(int id);
    }
}
