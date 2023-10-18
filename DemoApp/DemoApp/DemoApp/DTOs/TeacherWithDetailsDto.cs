namespace DemoApp.DTOs
{
    public class TeacherWithDetailsDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int YearsOfExperience { get; set; }
        public PersonDto? Person { get; set; }
    }
}
