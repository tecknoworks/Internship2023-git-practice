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
    public class TeacherController : ControllerBase
    {

        private ITeacherLogicService _teacherLogicService;
        private IMapper _mapper;

        public TeacherController(ITeacherLogicService _teacherLogicService, IMapper _mapper)
        {
            this._teacherLogicService = _teacherLogicService;
            this._mapper = _mapper;
        }

        //create student 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("/CreateTeacher/{id}")]
        public async Task<ActionResult<TeacherDtoForGet>> CreateTeacher([FromBody] TeacherDtoForCreate teacherDtoForCreate, int id)
        {
            try
            {
                Teacher teacher = _mapper.Map<Teacher>(teacherDtoForCreate);
                return Ok(_mapper.Map<TeacherDtoForGet>(await _teacherLogicService.CreateTeacher(teacher, id)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get teachers
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/GetTeachers")]
        public async Task<ActionResult<IEnumerable<TeacherDtoForGet?>>> GetTeachers()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<TeacherDtoForGet>>(await _teacherLogicService.GetTeachers()));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
