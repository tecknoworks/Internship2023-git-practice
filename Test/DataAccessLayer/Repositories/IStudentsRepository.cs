using BusinessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IStudentsRepository
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudentByID(int id);
        public void DelateStudent(int id);
        public Student CreateStudent(Student student);
        public Student UpdateStudent(Student updatedStudent, int id);

    }
}
