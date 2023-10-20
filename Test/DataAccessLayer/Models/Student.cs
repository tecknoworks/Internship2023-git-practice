using DataAccessLayer.Models;

namespace BusinessLayer.Models
{
    public class Student
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int? Grades {  get; set; }
       

        public Person? Person { get; set; }=null;
    }
}
