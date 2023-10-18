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
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersons()
        {
            var persons = await _personService.GetPersonsAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("CreatePerson")]
        public async Task<ActionResult<PersonDto>> CreatePerson([FromBody]PersonDtoWithoutId newPerson)
        {
            var person = _mapper.Map<Person>(newPerson);
            return Ok(await _personService.CreatePersonAsync(person));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdatePerson/{personId}")]
        public async Task<ActionResult<PersonDto>> UpdatePerson(int personId, [FromBody]PersonDtoWithoutId updatedPerson)
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
    }
}
