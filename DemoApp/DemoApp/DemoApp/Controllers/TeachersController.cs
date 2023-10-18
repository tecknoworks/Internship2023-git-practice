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
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachers()
        {
            return Ok(await _teachersService.GetTeachersAsync());
        }

        [HttpPost("CreateTeacher/{personId}")]
        public async Task<ActionResult<TeacherDto>> CreateTeacher([FromRoute]int personId, [FromBody] TeacherDtoWithoutId newTeacher)
        {
            var teacher = _mapper.Map<Teacher>(newTeacher);

            var createdTeacher = await _teachersService.CreateTeacherAsync(personId, teacher);

            return Ok(_mapper.Map<TeacherDto>(createdTeacher));
        }

    }
}
