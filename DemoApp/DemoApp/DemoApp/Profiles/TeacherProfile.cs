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
            CreateMap<TeacherWithDetailsDto, Teacher>();
            CreateMap<Teacher, TeacherWithDetailsDto>();
        }
    }
}
