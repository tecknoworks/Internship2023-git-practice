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

        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                return await _studentService.GetStudentsAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> StudentExistsAsync(int studentId)
        {
            try
            {
                return await _studentService.StudentExistsAsync(studentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Student> CreateStudent(int personId, Student newStudent)
        {
            try
            {
                return await _studentService.CreateStudentAsync(personId, newStudent);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task DeleteStudent(int studentId)
        {
            try
            {
                await _studentService.DeleteStudentAsync(studentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
