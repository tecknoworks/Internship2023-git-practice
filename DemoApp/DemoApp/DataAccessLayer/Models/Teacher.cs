namespace DataAccessLayer.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int YearsOfExperience { get; set; }  
        public Person? Person { get; set; }
    }
}
