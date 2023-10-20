using BusinessLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class StudentLogicService : IStudentLogicService
    {
        private IStudentService _studentService;
       
        public StudentLogicService(IStudentService _studentService)
        {
            this._studentService = _studentService;
        }

        //create student
        public async Task<Student?> CreateStudent(Student student, int id)
        {
            try
            {
                var createdStudent = await _studentService.CreateStudent(student,id);
                return createdStudent;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //get students
        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                IEnumerable<Student> students = await _studentService.GetStudents();
                return students;
            }catch (Exception)
            {
                throw;
            }
        }

        //detele student
        public async Task<string> DeleteStudent(int id)
        {
            try
            {
               return await _studentService.DeleteStudent(id);
            }
            catch (Exception)
            {
                throw;
            }
        }






    }
}
