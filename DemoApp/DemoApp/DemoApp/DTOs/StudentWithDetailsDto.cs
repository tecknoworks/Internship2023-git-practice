using DataAccessLayer.Models;

namespace DemoApp.DTOs
{
    public class StudentWithDetailsDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int Grade { get; set; }
        public PersonDto? Person { get; set; }
    }
}
