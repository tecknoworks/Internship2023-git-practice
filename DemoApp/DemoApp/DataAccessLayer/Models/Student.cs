using DataAccessLayer.Models;

namespace BusinessLayer.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int PersonId { get; set; }   
        public int Grade { get; set; }
        public Person? Person { get; set; }
    }
}
