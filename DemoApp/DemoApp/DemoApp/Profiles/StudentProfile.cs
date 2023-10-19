using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer.Models;
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
            CreateMap<Student, StudentWithDetailsDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
               .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Person.Branch))
               .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Person.Section))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Person.Gender));
        }
    }
}
