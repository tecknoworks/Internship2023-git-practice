using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class TeachersService : ITeachersService
    {
        private readonly ITeachersDataService _teachersDataService;
        public TeachersService(ITeachersDataService teachersDataService)
        {
            _teachersDataService = teachersDataService; 
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            try
            {
                return await _teachersDataService.GetTeachersAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Teacher> CreateTeacherAsync(int personId, Teacher newTeacher)
        {
            try
            {
                return await _teachersDataService.CreateTeacherAsync(personId, newTeacher);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}

