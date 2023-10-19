using BusinessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IStudentsService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<bool> StudentExistsAsync(int studentId);
        Task<Student> CreateStudent(int personId, Student newStudent);
        Task<string> DeleteStudent(int studentId);
    }
}
