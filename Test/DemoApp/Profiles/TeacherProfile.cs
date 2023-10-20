using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer.Models;
using DemoApp.DTOs;

namespace DemoApp.Profiles
{
    public class TeacherProfile: Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherDtoForGet, Teacher>();
            CreateMap<Teacher, TeacherDtoForGet>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Person.Gender));

            CreateMap<TeacherDtoForCreate, Teacher>();
            CreateMap<Teacher, TeacherDtoForCreate>();
        }
    }
}
