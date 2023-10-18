using BusinessLayer.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataAccessLayer.Repositories
{
//Use try-catch blocks when dealing with unpredictable errors that are out of your control.
//Use if statements when you want to check a condition that is within your control/ if you have accees to the data.

    public class StudentsRepository : IStudentsRepository
    {
        //get all students
        public async Task<IEnumerable<Student>>  GetStudents()
        {
                return await DataSource();
        }

        //get by id
        public async Task<Student?> GetStudentByID(int id)
        {
                List<Student> students = await DataSource();
                if(students== null)
                {
                throw new Exception("The student list is null");
                }
                if (!students.Exists(student => student.Id == id))
                {
                    throw new KeyNotFoundException($"Student with the ID {id} not found");
                }
                try
                {
                    return await Task.FromResult(students.FirstOrDefault(studen => studen.Id == id));
                }
                catch (Exception ex) 
                {
                    throw new Exception("Something went wrong when getting the result ");
                }
        }

        //delete user
        public async Task<Student> DelateStudent(int id)
        {
            List<Student> students= await DataSource();
            if (students == null)
            {
                throw new Exception("The student list is null");
            }

            if (!students.Exists(students => students.Id == id)) {
                throw new KeyNotFoundException($"Student with the ID {id} not found");
            }
            try
            {
                Student student = students.FirstOrDefault(student => student.Id == id);
                students.Remove(student);
                return student;
            }catch (Exception)
            {
                throw new Exception("Something went wrong when removing the user ");
            }
            
        }


        //create user
        public async Task<Student> CreateStudent(Student student)
        {
            try
            {
                List<Student> students = await DataSource();
                int index = students.Last().Id;
                student.Id = index + 1;
                students.Add(student);
                return await Task.FromResult(student);
            }catch(Exception)
            {
                throw new Exception("Something went wrong when removing the user");
            }

            
        }

        //update user
        public async Task<Student> UpdateStudent(Student updatedStudent, int id)
        {
            if (!students.Exists(students => students.Id == id))
            {
                throw new KeyNotFoundException($"Student with the ID {id} not found");
            }
            try
            {
                students = students.Select(student => student.Id == id ? updatedStudent : student).ToList();
                return await Task.FromResult(updatedStudent);
            }catch(Exception)
            {
                throw new Exception("Something went wrong when updating the user");
            }
           
        }

        public async Task <List<Student>> DataSource()
        {
            return await Task.FromResult(students);
        }

        private List<Student> students = new List<Student>()
            {
                new Student() { Id = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { Id = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
                new Student() { Id = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { Id = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
                new Student() { Id = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
    }
}
