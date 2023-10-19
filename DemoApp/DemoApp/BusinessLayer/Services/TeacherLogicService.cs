using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class TeacherLogicService:ITeacherLogicService
    {
        private ITeacherServices _teacherService;

        public TeacherLogicService(ITeacherServices teacherService)
        {
            _teacherService = teacherService;
        }

        public async Task<string> CreateTeacherLogic(int personId, Teacher teacher)
        {
            try
            {
                return await _teacherService.CreateTeacher(personId, teacher);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in BL -> Teacher ", ex);
            }
        }

        public async Task<IList> GetAllTeachersLogic()
        {
            try
            {
                return await _teacherService.GetAllTeachers();
            }
            catch(Exception ex)
            {
                throw new Exception("Something went wrong in BL -> Teacher ", ex);
            }
        }
    }
}
