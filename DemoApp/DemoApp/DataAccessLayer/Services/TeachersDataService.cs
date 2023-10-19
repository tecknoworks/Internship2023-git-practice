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

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            try
            {
                return await _context.Teachers.Include(t => t.Person).ToListAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Teacher> CreateTeacherAsync(int personId, Teacher newTeacher)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(person => person.Id == personId);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with id {personId} does not exist.");
            }
            try 
            {
                newTeacher.PersonId = personId;
                newTeacher.Person = person;
                _context.Teachers.Add(newTeacher);
                await _context.SaveChangesAsync();
                return newTeacher;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

    }
}
