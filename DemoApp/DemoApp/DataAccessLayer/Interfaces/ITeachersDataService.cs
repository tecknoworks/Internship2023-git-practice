using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface ITeachersDataService
    {
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<Teacher> CreateTeacherAsync(int personId, Teacher newTeacher);
    }
}
