using DataAccessLayer.Models;

namespace DemoApp.DTOs
{
    public class StudentWithDetailsDto
    {
        public int Id { get; set; } 
        public int Grade { get; set; }
        public string? Name { get; set; }
        public string? Branch { get; set; }
        public string? Section { get; set; }
        public string? Gender { get; set; }
    }
}
