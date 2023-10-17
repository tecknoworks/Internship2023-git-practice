using BusinessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;
       
        public StudentsService(IStudentsRepository studentsRepository)
        { 
            _studentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentsRepository.GetStudentsAsync();

        }

        public async Task<Student?> GetStudentAsync(int studentId)
        {
            return await _studentsRepository.GetStudentAsync(studentId);
        }

        public async Task<bool> StudentExistsAsync(int studentId)
        {
            return await _studentsRepository.StudentExistsAsync(studentId);
        }

        public Task CreateStudent(Student newStudent)
        {
            _studentsRepository.CreateStudent(newStudent);
            return Task.CompletedTask;
        }

        public Task DeleteStudent(int studentId)
        {
            try
            {
                _studentsRepository.DeleteStudent(studentId);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task UpdateStudent(int studentId, Student newStudent) 
        {
            _studentsRepository.UpdateStudent(studentId, newStudent);
            return Task.CompletedTask;
        }
    }
}
