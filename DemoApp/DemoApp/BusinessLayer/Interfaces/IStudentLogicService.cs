using BusinessLayer.Models;
using System.Collections;

namespace BusinessLayer.Interfaces
{
    public interface IStudentLogicService
    {
        Task<Student> CreateStudentLogic(int personId, Student student);
        Task<IList> GetAllStudentsLogic();

        Task DeleteStudentLogic(int id);
    }
}
