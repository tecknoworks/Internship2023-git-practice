
using BusinessLayer.Models;

namespace BusinessLayer.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetUsers();
    }
}
