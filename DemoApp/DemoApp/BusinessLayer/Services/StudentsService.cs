using BusinessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class StudentsService : IStudentsService
    {
        private IStudentsRepository studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }
        public async Task<List<Student>> GetUsers()
        {
            // TODO:
            // Implement the method to return the list of students
            return await studentsRepository.GetStudentsAsync();

            throw new NotImplementedException();
        }
        
        public async Task<Student> GetUsersById(int id)
        {
            return await studentsRepository.GetStudentByIdAsync(id);
            throw new NotImplementedException();
        }

        public async Task DeleteUserById(int id)
        {
            await studentsRepository.DeleteStudentById(id);
        }

        public async Task UpdateUserById(int id, Student student)
        {
            await studentsRepository.UpdateStudentById(id, student);
        }

        public void AddNewUser(Student student)
        {
            studentsRepository.AddNewStudent(student);
        }
    }
}
