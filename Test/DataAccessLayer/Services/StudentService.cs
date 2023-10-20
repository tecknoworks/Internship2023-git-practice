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
    public class StudentService:IStudentService
    {
        private SchoolDbContext schoolDbContext;
        public StudentService(SchoolDbContext schoolDbContext)
        {
            this.schoolDbContext = schoolDbContext;
        }


        //create student
        public async Task<Student?> CreateStudent(Student student, int id)
        {
            Person person = await schoolDbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            try
            {
                student.Person = person;
                student.PersonId = id;
                await schoolDbContext.Students.AddAsync(student);
                await schoolDbContext.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create new student", ex);
            }
        }

        //get all students
        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                List<Student> students = await schoolDbContext.Students.Include(s=>s.Person).ToListAsync();
                if (students == null)
                {
                    throw new ArgumentNullException(nameof(students));
                }
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to students", ex);
            }  
        }

        public async Task<string> DeleteStudent(int id)
        {
            Student studentById = await schoolDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (studentById == null)
            {
                throw new ArgumentNullException(nameof(studentById));
            }
            try
            {
                schoolDbContext.Students.Remove(studentById);
                await schoolDbContext.SaveChangesAsync();
                return $"Student with the id {id} was deleted.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}
