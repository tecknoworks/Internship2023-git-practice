using BusinessLayer.Models;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface ITeacherService
    {
        public Task<Teacher?> CreateTeacher(Teacher teacher, int id);
        public Task<IEnumerable<Teacher>> GetTeachers();
    }
}
