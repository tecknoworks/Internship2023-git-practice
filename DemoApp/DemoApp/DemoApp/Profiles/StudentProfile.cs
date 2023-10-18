using AutoMapper;
using BusinessLayer.Models;
using DemoApp.DTOs;

namespace DemoApp.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDtoWithoutId, Student>();
        }
    }
}
