
using BusinessLayer.Models;

namespace BusinessLayer.Services
{
    public interface IStudentsService
    {
        public IEnumerable<Student> GetUsers();
        public Student GetStudentByID(int id);
        public void DelateStudent(int id);
        public Student CreateStudent(Student student);
        public Student UpdateStudent(Student updatedStudent, int id);
    }
}
