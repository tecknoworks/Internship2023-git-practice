using BusinessLayer.Models;
using System.Security.Cryptography;

namespace DataAccessLayer.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
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
            _students.Add(newStudent);
        }

        public void DeleteStudent(int studentId)
        {
            var student = _students.Where(student => student.Id == studentId).FirstOrDefault();

            if (student == null) 
            {
                throw new Exception($"Student with id {studentId} does not exist.");
            }

            _students.Remove(student);
        }

        public void UpdateStudent(int studentId, Student updatedStudent)
        {
            _students = _students.Select(student => student.Id == studentId ? updatedStudent : student).ToList(); 
        }

        private List<Student> _students = new List<Student>()
        {
            new Student() { Id = 101, Name = "Dalmatieni", Branch = "CSE", Section = "A", Gender = "Male" },
            new Student() { Id = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
            new Student() { Id = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
            new Student() { Id = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
            new Student() { Id = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
        };

        private async Task<IEnumerable<Student>> DataSourceAsync()
        {
            return await Task.FromResult(_students);
        }
    }
}
