using BusinessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using DataAccessLayer.Models;

namespace DataAccessLayer.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<string> CreateStudent(int personId, Student student)
        {
            var message = "Student created successfully";
            if (personId <= 0)
            {
                throw new Exception("PersonId not valid");
            }
            if(student == null)
            {
                throw new Exception("Student object can't be null");
            }
            try
            {
                student.PersonId = personId;

                
                await _applicationDbContext.Students.AddAsync(student);
                await _applicationDbContext.SaveChangesAsync();

                return message;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in Data layer -> Student ", ex);
            }
        }

        public async Task<IList> GetAllStudents()
        {
            try
            {
                var newStudents = await _applicationDbContext.Students.Join(_applicationDbContext.Persons,
                   student => student.PersonId,
                   person => person.Id,
                   (student, person) =>
                   new StudentResponse
                   {
                       Id = student.Id,
                       Name = person.Name,
                       Age = person.Age,
                       Gender = person.Gender,
                       Branch = student.Branch,
                       Section = student.Section
                   }).ToListAsync();

                return newStudents;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in Data layer -> Student ", ex);
            }
        }

        public async Task<string> DeleteStudent(int id)
        {

            var message = "Student was deleted successfully";

            if(id <= 0)
            {
                throw new Exception("Id must be greater then 0");
            }
            try
            {
                Student? student = await _applicationDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
                
                if(student == null)
                {
                    throw new Exception("Invalid id");
                }

                _applicationDbContext.Students.Remove(student);
                await _applicationDbContext.SaveChangesAsync();
                return message;

            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in Data layer -> Student ", ex);
            }
        }
    }
}
