using BusinessLayer.Models;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class TeacherService:ITeacherService
    {
      
            private SchoolDbContext schoolDbContext;
            public TeacherService(SchoolDbContext schoolDbContext)
            {
                this.schoolDbContext = schoolDbContext;
            }


            //create teacher
            public async Task<Teacher?> CreateTeacher(Teacher teacher, int id)
            {
                Person person = await schoolDbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);

                if (person == null)
                {
                    throw new ArgumentNullException(nameof(person));
                }
                try
                {
                    teacher.Person = person;
                    teacher.PersonId = id;
                    await schoolDbContext.Teachers.AddAsync(teacher);
                    await schoolDbContext.SaveChangesAsync();
                    return teacher;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to create new student", ex);
                }
            }

        //get all teacher
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            try
            {
                List<Teacher> teachers = await schoolDbContext.Teachers.Include(s => s.Person).ToListAsync();
                if (teachers == null)
                {
                    throw new ArgumentNullException(nameof(teachers));
                }
                return teachers;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to students", ex);
            }
        }
    }
}
