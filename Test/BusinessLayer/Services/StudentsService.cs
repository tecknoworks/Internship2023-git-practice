using BusinessLayer.Models;
using DataAccessLayer.Repositories;
using System.Runtime.ExceptionServices;

namespace BusinessLayer.Services
{
    public class StudentsService : IStudentsService{


        private readonly IStudentsRepository studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }


        //get all students
        public async Task<IEnumerable<Student>> GetUsers()
        {
            try
            {
                return await studentsRepository.GetStudents();
            }
            catch(Exception ex )
            {
                throw ex;
            }
        }

        //get student by id
        public async Task<Student?>  GetStudentByID(int id)
        {
            try
            {
                return await studentsRepository.GetStudentByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //delete user
        public async Task DelateStudent(int id)
        {
            try
            {
                await studentsRepository.DelateStudent(id);
            }catch(Exception ex)
            {
                throw ex; 
            }
        }

        //create user
        public async Task<Student>  CreateStudent(Student student)
        {
            try
            {
                return await studentsRepository.CreateStudent(student);
            }catch (Exception ex)
            {
                throw ex;
            }
           
        }

        //update user
        public async Task<Student> UpdateStudent(Student updatedStudent, int id)
        {
            try
            {
                return await studentsRepository.UpdateStudent(updatedStudent, id);
            }catch (Exception ex)
            {
                throw ; 
            }
            
        }
    }
}
