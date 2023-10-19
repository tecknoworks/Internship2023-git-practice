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

        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                return await _context.Students.Include(s => s.Person).ToListAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<bool> StudentExistsAsync(int studentId)
        {
            try
            {
                return await _context.Students.AnyAsync(student => student.Id == studentId);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Student> CreateStudentAsync(int personId, Student newStudent)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(person => person.Id == personId);   

            if (person == null) 
            {
                throw new KeyNotFoundException($"Person with id {personId} does not exist.");
            }

            try
            {
                newStudent.Person = person;
                newStudent.PersonId = personId;
                await _context.Students.AddAsync(newStudent);
                await _context.SaveChangesAsync();
                return newStudent;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<string> DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(student => student.Id == studentId);
            if (student == null) 
            {
                throw new Exception($"Student with id {studentId} does not exist.");
            }

            try 
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return $"Deleted student with id {studentId}";
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
