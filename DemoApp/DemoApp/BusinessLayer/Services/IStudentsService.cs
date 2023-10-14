
using BusinessLayer.Models;

namespace BusinessLayer.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetStudentAsync(int studentId);
        Task<bool> StudentExistsAsync(int studentId);
        void CreateStudent(Student newStudent);
        void DeleteStudent(int studentId);
    }
}
