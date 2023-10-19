using DataAccessLayer.DTOs;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DataAccessLayer.Services
{
    public class TeacherServices:ITeacherServices
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TeacherServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<string> CreateTeacher(int personId, Teacher teacher)
        {
            var message = "Teacher created successfully";
            if(personId <= 0)
            {
                throw new ArgumentException("Person id not valid ");
            }
            if (teacher == null)
            {
                throw new Exception("Teacher object can't be null");
            }
            try
            {
                teacher.PersonId = personId;

                await _applicationDbContext.Teachers.AddAsync(teacher);
                await _applicationDbContext.SaveChangesAsync();

                return message;
            }catch(Exception ex)
            {
                throw new Exception("Something went wrong in Data layer -> Teacher",ex);
            }
        }

        public async Task<IList> GetAllTeachers()
        {
            try
            {
                var newTeachers = await _applicationDbContext.Teachers.Join(_applicationDbContext.Persons,
                    teacher => teacher.PersonId,
                    person => person.Id,
                    (teacher, person) =>
                    new TeacherResponse
                    {
                        Id = teacher.Id,
                        Name = person.Name,
                        Age = person.Age,
                        Gender  = person.Gender,
                        CourseTeaching = teacher.CourseTeaching

                    }).ToListAsync();

                return newTeachers;
            }
            catch(Exception ex)
            {
                throw new Exception("Something went wrong in Data layer->Teacher ", ex);
            }
        }
    }
}
