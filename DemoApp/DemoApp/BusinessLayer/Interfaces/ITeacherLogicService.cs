using BusinessLayer.Models;
using DataAccessLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITeacherLogicService
    {
        Task<Teacher> CreateTeacherLogic(int personId, Teacher teacher);
        Task<IList> GetAllTeachersLogic();
    }
}
