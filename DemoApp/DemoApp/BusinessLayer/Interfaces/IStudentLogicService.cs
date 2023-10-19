using BusinessLayer.Models;
using System.Collections;

namespace BusinessLayer.Interfaces
{
    public interface IStudentLogicService
    {
        Task<string> CreateStudentLogic(int personId, Student student);
        Task<IList> GetAllStudentsLogic();

        Task<string> DeleteStudentLogic(int id);
    }
}
