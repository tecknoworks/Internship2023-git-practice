
using BusinessLayer.Models;

namespace BusinessLayer.Services
{
    public interface IStudentsService
    {
        public Task<IEnumerable<Student>>  GetUsers();
        public Task<Student?> GetStudentByID(int id);
        public Task DelateStudent(int id);
        public Task<Student> CreateStudent(Student student);
        public Task<Student> UpdateStudent(Student updatedStudent, int id);
    }
}
