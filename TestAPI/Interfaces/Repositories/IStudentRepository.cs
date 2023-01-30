using TestAPI.Models;

namespace TestAPI.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<ICollection<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Response> CreateStudent(Student student);
        Task<Response> UpdateStudent(Student student);
        Task<Response> DeleteStudent(int id);
        Task<bool> Save();
    }
}
