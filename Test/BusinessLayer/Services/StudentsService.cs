using BusinessLayer.Models;
using DataAccessLayer.Repositories;

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
           return await studentsRepository.GetStudents();
        }

        //get student by id
        public async Task<Student>  GetStudentByID(int id)
        {
            try
            {
                return await studentsRepository.GetStudentByID(id);
            }
            catch(Exception) 
            {
                throw;
            }
        }


        //delete user
        public async Task DelateStudent(int id)
        {
            try
            {
                await studentsRepository.DelateStudent(id);
            }catch(Exception)
            {
                throw;
            }
        }

        //create user
        public async Task<Student>  CreateStudent(Student student)
        {
           return await studentsRepository.CreateStudent(student);
        }

        //update user
        public async Task<Student> UpdateStudent(Student updatedStudent, int id)
        {
            return await studentsRepository.UpdateStudent(updatedStudent, id);
        }
    }
}
