
using BusinessLayer.Models;

namespace BusinessLayer.Services
{
    public interface IStudentsService
    {
        Task<List<Student>> GetUsers();
        Task<Student> GetUsersById(int id);

        Task DeleteUserById(int id);
        Task UpdateUserById(int id, Student student);
        void AddNewUser(Student student);
    }
}
