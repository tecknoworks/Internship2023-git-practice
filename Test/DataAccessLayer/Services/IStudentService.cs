using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IStudentService
    {
        public Task<Student?> CreateStudent(Student student, int id);
        public Task<IEnumerable<Student>> GetStudents();
        public Task<string> DeleteStudent(int id);
    }
}
