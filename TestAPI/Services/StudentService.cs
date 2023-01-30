using AutoMapper;
using TestAPI.Interfaces.Repositories;
using TestAPI.Interfaces.Services;
using TestAPI.Models;
using TestAPI.Models.DTO.City;
using TestAPI.Repositories;

namespace TestAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository= studentRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Student>> GetAll()
        {
            //return _mapper.Map<ICollection<Student>>(await _studentRepository.GetAll());
            return await _studentRepository.GetAll();
        }

        public async Task<Student> GetById(int id)
        {
            //return _mapper.Map<Student>(await _studentRepository.GetById(id));
            return await _studentRepository.GetById(id);
        }

        public async Task<Response> CreateStudent(Student student)
        {
            //return await _studentRepository.CreateStudent(_mapper.Map<Student>(city));
            return await _studentRepository.CreateStudent(student);
        }

        public async Task<Response> UpdateStudent(Student student)
        {
            //return await _studentRepository.UpdateStudent(_mapper.Map<Student>(city));
            return await _studentRepository.UpdateStudent(student);
        }

        public async Task<Response> DeleteStudent(int id)
        {
            //return await _studentRepository.DeleteStudent(id);
            return await _studentRepository.DeleteStudent(id);
        }
    }
}
