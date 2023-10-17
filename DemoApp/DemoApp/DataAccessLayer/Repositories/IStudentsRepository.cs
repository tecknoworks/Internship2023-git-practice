using BusinessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetStudentAsync(int studentId);
        Task<bool> StudentExistsAsync(int studentId);
        Task CreateStudent(Student newStudent);
        Task DeleteStudent(int studentId);
        Task UpdateStudent(int studentId, Student newStudent);
    }
}
