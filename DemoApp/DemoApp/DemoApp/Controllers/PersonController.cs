using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonLogicService _personService;


        public PersonController(IPersonLogicService personService)
        {
            this._personService = personService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]

        public async Task<ActionResult<string>> CreateNewPerson(Person person)
        {
            try
            {
                return await _personService.CreatePersonLogic(person);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<string>> UpdateExistingPerson(int id, Person person)
        {
            try
            {
                return await _personService.UpdatePersonLogic(id, person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
