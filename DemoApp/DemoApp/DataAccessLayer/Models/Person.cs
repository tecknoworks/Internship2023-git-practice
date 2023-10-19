using BusinessLayer.Models;

namespace DataAccessLayer.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Branch { get; set; }
        public string? Section { get; set; }
        public string? Gender { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }  

    }
}
