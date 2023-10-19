using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface ITeachersDataService
    {
        Task<List<Teacher>> GetTeachersAsync();
        Task<Teacher> CreateTeacherAsync(int personId, Teacher newTeacher);
    }
}
