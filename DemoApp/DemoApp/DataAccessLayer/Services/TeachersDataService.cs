using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class TeachersDataService : ITeachersDataService
    {
        private readonly SchoolContext _context;
        public TeachersDataService(SchoolContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> CreateTeacherAsync(int personId, Teacher newTeacher)
        {
            newTeacher.PersonId = personId;
            _context.Teachers.Add(newTeacher);
            await _context.SaveChangesAsync();
            return newTeacher;
        }

    }
}
