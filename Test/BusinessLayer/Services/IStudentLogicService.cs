using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IStudentLogicService
    {
        public Task<Student?> CreateStudent(Student student, int id);
        public Task<IEnumerable<Student>> GetStudents();
        public Task<string> DeleteStudent(int id);

        }
}
