using AutoMapper;
using BusinessLayer.Models;
using DemoApp.DTOs;

namespace DemoApp.Profiles
{
    public class StudentProfile :Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDtoForGet, Student>();
            CreateMap<Student, StudentDtoForGet>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Person.Gender));

            CreateMap<StudentDtoForCreate, Student>();
            CreateMap<Student, StudentDtoForCreate>();
        }
    }
}
