using BusinessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IStudentsRepository
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task DeleteStudentById(int id);
        public Task UpdateStudentById(int id, Student student);
        public void AddNewStudent(Student student);
    }
}
