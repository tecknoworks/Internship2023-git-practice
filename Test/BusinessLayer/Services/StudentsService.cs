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
        public IEnumerable<Student> GetUsers()
        {
           return studentsRepository.GetStudents();
        }

        //get student by id
        public Student GetStudentByID(int id)
        {
            try
            {
                return studentsRepository.GetStudentByID(id);
            }
            catch(Exception) 
            {
                throw;
            }
        }


        //delete user
        public void DelateStudent(int id)
        {
            try
            {
                studentsRepository.DelateStudent(id);
            }catch(Exception)
            {
                throw;
            }
        }

        //create user
        public Student CreateStudent(Student student)
        {
           return studentsRepository.CreateStudent(student);
        }

        //update user
        public Student UpdateStudent(Student updatedStudent, int id)
        {
            return studentsRepository.UpdateStudent(updatedStudent, id);
        }
    }
}
