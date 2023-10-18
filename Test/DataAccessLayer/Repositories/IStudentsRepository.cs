using BusinessLayer.Models;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IStudentsRepository
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<Student?> GetStudentByID(int id);
        public Task<Student> DelateStudent(int id);
        public Task<Student> CreateStudent(Student student);
        public Task<Student> UpdateStudent(Student updatedStudent, int id);

    }
}
