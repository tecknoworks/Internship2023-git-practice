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

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            return await _teachersDataService.GetTeachersAsync();
        }

        public async Task<Teacher> CreateTeacherAsync(int personId, Teacher newTeacher)
        {
            return await _teachersDataService.CreateTeacherAsync(personId, newTeacher);
        }
    }
}

