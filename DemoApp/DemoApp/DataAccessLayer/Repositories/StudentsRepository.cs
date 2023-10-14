using BusinessLayer.Models;
using System.Security.Cryptography;

namespace DataAccessLayer.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { Id = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
            new Student() { Id = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
            new Student() { Id = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
            new Student() { Id = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
            new Student() { Id = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
        };

        private async Task<IEnumerable<Student>> DataSourceAsync()
        {
            return await Task.FromResult(_students);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await DataSourceAsync();
        }

        public async Task<Student?> GetStudentAsync(int studentId)
        {
            var students = await DataSourceAsync();
            return students.FirstOrDefault(student => student.Id == studentId);
        }

        public async Task<bool> StudentExistsAsync(int studentId)
        {
            var students = await DataSourceAsync();
            return students.Any(student => student.Id == studentId);
        }

        public void CreateStudent(Student newStudent)
        {
            int maxId = _students.Max(student => student.Id);
            newStudent.Id = maxId + 1;
            _students.Add(newStudent);
        }

        public void DeleteStudent(int studentId)
        {
            _students.RemoveAll(student => student.Id == studentId);
        }
    }
}
