using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections;

namespace BusinessLayer.Services
{
    public class StudentLogicService : IStudentLogicService
    {
       private IStudentServices _studentServices;

        public StudentLogicService(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public async Task<string> CreateStudentLogic(int personId, Student student)
        {
            try
            {
                return await _studentServices.CreateStudent(personId, student);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in BL -> Student ", ex);
            }
        }

        public async Task<IList> GetAllStudentsLogic()
        {
            try
            {
                return await _studentServices.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception("Somthing went wrong in BL -> Students", ex);
            }
        }

        public async Task<string> DeleteStudentLogic(int id)
        {
            try
            {
                return await _studentServices.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Somthing went wrong in BL Students", ex);
            }
        }
    }
}
