using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsDataService _studentService;
       
        public StudentsService(IStudentsDataService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentService.GetStudentsAsync();

        }

        public async Task<bool> StudentExistsAsync(int studentId)
        {
            return await _studentService.StudentExistsAsync(studentId);
        }

        public async Task<Student> CreateStudent(int personId, Student newStudent)
        {
            return await _studentService.CreateStudentAsync(personId, newStudent);
        }

        public Task DeleteStudent(int studentId)
        {
            try
            {
                _studentService.DeleteStudentAsync(studentId);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
