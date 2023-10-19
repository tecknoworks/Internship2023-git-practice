using DataAccessLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITeacherServices
    {
        Task<Teacher> CreateTeacher(int personId, Teacher teacher);
        Task<IList> GetAllTeachers();
    }
}
