using AutoMapper;
using DataAccessLayer.Models;
using DemoApp.DTOs;

namespace DemoApp.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile() 
        {
            CreateMap<TeacherDto, Teacher>();
            CreateMap<TeacherDtoWithoutId, Teacher>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<Teacher, TeacherWithDetailsDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Person.Branch))
                .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Person.Section))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Person.Gender));
        }
    }
}
