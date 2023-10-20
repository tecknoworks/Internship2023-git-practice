using AutoMapper;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLayer.Models;
using DemoApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonLogicService _personLogicService;
        private IMapper _mapper;
        public PersonController(IPersonLogicService _personLogicService, IMapper mapper) { 
        this._personLogicService = _personLogicService;
           _mapper = mapper;
        }


        //create person 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("/person")]
        public async Task<Person?> CreateStudent([FromBody] Person person)
        {
            try
            {
                return await _personLogicService.CreatePerson(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //update person
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("/person/{id}")]
        public async Task<PersonDto> UpdatePerson(int id, PersonDto person)
        {
            try
            {
                Person personToUpdate = await _personLogicService.GetPersonById(id);

                if (person == null)
                {
                    throw new Exception($"Person with id {id} does not exist.");
                }
                _mapper.Map(person, personToUpdate);
                await _personLogicService.UpdatePerson(id, personToUpdate);
                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //get person by id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/person/{id}")]
        public async Task<Person?> GetPersonById(int id)
        {
            try
            {
               return await _personLogicService.GetPersonById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
