using AutoMapper;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLayer.Models;
using DemoApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentLogicService _studentLogicService;
        private IMapper _mapper;

        public StudentController(IStudentLogicService _studentLogicService, IMapper _mapper)
        {
            this._studentLogicService = _studentLogicService;
            this._mapper = _mapper;
        }

        //create student 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("/CreateStudent/{id}")]
        public async Task<ActionResult<StudentDtoForGet>> CreateStudent([FromBody] StudentDtoForCreate studentDtoForCreate, int id)
        {
            try
            {
                Student student= _mapper.Map<Student>(studentDtoForCreate);
                return Ok(_mapper.Map<StudentDtoForGet>(await _studentLogicService.CreateStudent(student, id)));
            }
            catch (Exception)
            {
                throw;
            }
        }


        //get students
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/GetStudents")]
        public async Task <ActionResult<IEnumerable<StudentDtoForGet?>>> GetStudents()
        {
            try
            {
                return Ok(_mapper.Map <IEnumerable<StudentDtoForGet>> (await _studentLogicService.GetStudents()));
            }catch (Exception)
            {
                throw;
            }
        }

        //delete students
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("/DeleteStudents/{id}")]
        public async Task<ActionResult<string>> DeleteStudent(int id)
        {
            try
            {
                return Ok(await _studentLogicService.DeleteStudent(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
