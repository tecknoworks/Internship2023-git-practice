using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IStudentsDataService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> CreateStudentAsync(int personId, Student newStudent);
        Task<string> DeleteStudentAsync(int studentId);
        Task<bool> StudentExistsAsync(int studentId);
    }
}
