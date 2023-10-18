using BusinessLayer.Models;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class StudentsDataService : IStudentsDataService
    {
        private readonly SchoolContext _context;

        public StudentsDataService(SchoolContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<bool> StudentExistsAsync(int studentId)
        {
            return await _context.Students.AnyAsync(student => student.Id == studentId);
        }

        public async Task<Student> CreateStudentAsync(int personId, Student newStudent)
        {
            newStudent.PersonId = personId;
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(student => student.Id == studentId);
            if (student == null) 
            {
                throw new Exception($"Student with id {studentId} does not exist.");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
