using BusinessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        //get all students
        public async Task<IEnumerable<Student>>  GetStudents()
        {
            return await DataSource();
        }

        //get by id
        public async Task<Student> GetStudentByID(int id)
        {
            List<Student> students = await DataSource();
            if (!students.Exists(student => student.Id == id))
            {
                throw new Exception("Nu exista student!");
            }
            return await Task.FromResult(students.Where(studen => studen.Id == id).FirstOrDefault());
        }

        //delete user
        public async Task DelateStudent(int id)
        {
            List<Student> students= await DataSource();
            
            if(!students.Exists(students => students.Id == id)) {
                throw new Exception("Nu exista student!");
            }

            Student student = students.FirstOrDefault(student => student.Id == id);
            students.Remove(student);
        }


        //create user
        public async Task<Student> CreateStudent(Student student)
        {
            List<Student> students =await DataSource();
            int index= students.Last().Id;
            student.Id = index+1;
            students.Add(student);
            return await Task.FromResult (student);
        }

        //update user
        public async Task<Student> UpdateStudent(Student updatedStudent, int id)
        {
            if (!students.Exists(students => students.Id == id))
            {
                throw new Exception("Nu exista student!");
            }
            students = students.Select(student => student.Id == id ? updatedStudent : student).ToList();
            return await Task.FromResult(updatedStudent);
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
