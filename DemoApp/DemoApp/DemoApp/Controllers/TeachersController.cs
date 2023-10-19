using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using DemoApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersService _teachersService;
        private readonly IMapper _mapper;

        public TeachersController(ITeachersService teachersService, IMapper mapper) 
        {
            _teachersService = teachersService;
            _mapper = mapper;
        }

        [HttpGet("GetTeachers")]
        public async Task<ActionResult<List<TeacherWithDetailsDto>>> GetTeachers()
        {
            try
            {
                return Ok(_mapper.Map<List<TeacherWithDetailsDto>>(await _teachersService.GetTeachersAsync()));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost("CreateTeacher/{personId}")]
        public async Task<ActionResult<TeacherWithDetailsDto>> CreateTeacher([FromRoute]int personId, [FromBody] TeacherDtoWithoutId newTeacher)
        {
            var teacher = _mapper.Map<Teacher>(newTeacher);
            
            try
            {
                var createdTeacher = await _teachersService.CreateTeacherAsync(personId, teacher);
                return Ok(_mapper.Map<TeacherWithDetailsDto>(createdTeacher));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
