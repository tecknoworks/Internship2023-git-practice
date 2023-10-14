using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Models;

namespace DemoApp.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdateDto, Student>();
        }
    }
}
