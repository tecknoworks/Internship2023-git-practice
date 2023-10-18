using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITeachersService
    {
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<Teacher> CreateTeacherAsync(int personId, Teacher newTeacher);
    }
}
