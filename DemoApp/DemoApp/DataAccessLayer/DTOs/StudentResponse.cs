﻿namespace DataAccessLayer.DTOs
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }  
        public string? Branch { get; set; }
        public string? Section { get; set; } 

    }
}
