using DataAccessLayer.Models;

namespace BusinessLayer.Models
{
    public class Student 
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string? Branch { get; set; }
        public string? Section { get; set; }

        public Person? Person { get; set; }=null;
    }
}
