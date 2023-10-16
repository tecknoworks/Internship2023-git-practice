using BusinessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetStudentAsync(int studentId);
        Task<bool> StudentExistsAsync(int studentId);
        void CreateStudent(Student newStudent);
        void DeleteStudent(int studentId);
        void UpdateStudent(int studentId, Student newStudent);
    }
}
