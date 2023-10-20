using BusinessLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class TeacherLogicService : ITeacherLogicService
    {
        private ITeacherService _teacherService;

        public TeacherLogicService(ITeacherService _teacherService)
        {
            this._teacherService = _teacherService;
        }

        //create teacher
        public async Task<Teacher?> CreateTeacher(Teacher teacher, int id)
        {
            try
            {
                var createdTeacher = await _teacherService.CreateTeacher(teacher, id);
                return createdTeacher;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get teachers
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            try
            {
                IEnumerable<Teacher> teachers = await _teacherService.GetTeachers();
                return teachers;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
