using AutoMapper;
using DataAccessLayer.Models;
using DemoApp.DTOs;

namespace DemoApp.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile() 
        {
            CreateMap<PersonDto, Person>();
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDtoWithoutId, Person>();
        }
    }
}
