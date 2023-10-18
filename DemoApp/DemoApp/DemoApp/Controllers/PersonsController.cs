using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using DemoApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personService;
        private readonly IMapper _mapper;   

        public PersonsController(IPersonsService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetPersons")]
        public async Task<ActionResult<List<PersonDto>>> GetPersons()
        {
            try 
            {
                var persons = await _personService.GetPersonsAsync();
                return Ok(_mapper.Map<List<PersonDto>>(persons));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("CreatePerson")]
        public async Task<ActionResult<PersonDto>> CreatePerson([FromBody]PersonDtoWithoutId newPerson)
        {
            var person = _mapper.Map<Person>(newPerson);
            try
            {
                var createdPerson = await _personService.CreatePersonAsync(person);
                return Ok(_mapper.Map<PersonDto>(createdPerson));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdatePerson/{personId}")]
        public async Task<ActionResult<PersonDto>> UpdatePerson(int personId, [FromBody]PersonDtoWithoutId updatedPerson)
        {
            try
            {
                var person = await _personService.GetPersonAsync(personId);

                if (person == null)
                {
                    return NotFound($"Person with id {personId} does not exist.");
                }

                _mapper.Map(updatedPerson, person);

                await _personService.SaveChangesAsync();
    
                return Ok(updatedPerson);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }   
        }
    }
}
