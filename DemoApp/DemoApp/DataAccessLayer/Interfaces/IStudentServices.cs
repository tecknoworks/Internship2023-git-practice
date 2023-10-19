using BusinessLayer.Models;
using DataAccessLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IStudentServices
    {
        Task<Student> CreateStudent(int personId, Student student);
        Task<IList> GetAllStudents();
        Task DeleteStudent(int id);
    }
}
