
using BusinessLayer.Models;

namespace BusinessLayer.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetStudentAsync(int studentId);
        Task<bool> StudentExistsAsync(int studentId);
        Task CreateStudent(Student newStudent);
        Task DeleteStudent(int studentId);
        Task UpdateStudent(int studentId, Student newStudent);
    }
}
