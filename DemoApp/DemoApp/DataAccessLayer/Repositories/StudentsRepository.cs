using BusinessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        //TODO:
        //Implement the method to return the list of students

        private List<Student> _students = new List<Student>()
        {
            new Student() { Id = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
            new Student() { Id = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
            new Student() { Id = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
            new Student() { Id = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
            new Student() { Id = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
        };

        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public async Task <List<Student>> GetStudentsAsync()
        {
            List<Student> students = DataSourceAsync();
            return await Task.FromResult(students);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            Student? student = Students.Where(student => student.Id == id).FirstOrDefault();
            if (student == null)
            {
                throw new InvalidOperationException("Invalid id!");
            }
            return await Task.FromResult(student);
        }

        public async Task DeleteStudentById(int id)
        {
            if (id == 0)
                throw new Exception("Student doesn't exist!");
            Student? student = Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                throw new InvalidOperationException("Invalid id!");
            }
            await Task.FromResult(Students.Remove(student));

        }

        public async Task UpdateStudentById(int id, Student stud)
        {
            if (id == 0)
                throw new Exception("Student doesn't exist!");

            Student? newStudent = Students.FirstOrDefault(student => student.Id == id);

            if (newStudent == null)
            {
                throw new InvalidOperationException("Invalid id!");
            }

            var updatedStudentList = Students.Where(s => s.Id == id).Select(async student =>
            {
                student.Name = String.IsNullOrEmpty(stud.Name) ? newStudent.Name : stud.Name;
                student.Branch = String.IsNullOrEmpty(stud.Branch) ? newStudent.Branch : stud.Branch;
                student.Section = String.IsNullOrEmpty(stud.Section) ? newStudent.Section : stud.Section;
                student.Gender = String.IsNullOrEmpty(stud.Gender) ? newStudent.Gender : stud.Gender;

                return student;

            }).ToList();

            await Task.FromResult(updatedStudentList);
        }

        public void AddNewStudent(Student stud)
        {
            var index = Students.Last().Id;
            if (stud == null)
                throw new Exception("Student can't be null");

            Students.Add(new Student
            {
                Id = index+1,
                Name = stud.Name,
                Branch = stud.Branch,
                Section = stud.Section,
                Gender = stud.Gender
            });
        }

        public List<Student> DataSourceAsync()
        {
            return Students;
        }
    }
}
