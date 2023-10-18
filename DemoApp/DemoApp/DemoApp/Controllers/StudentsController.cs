using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DemoApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetStudents")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreateStudent/{personId}")]
        public async Task<ActionResult<StudentDto>> CreateStudent(int personId, [FromBody] StudentDtoWithoutId newStudent)
        {

            var student = _mapper.Map<Student>(newStudent);

            await _studentService.CreateStudent(personId, student);

            var studentToReturn = _mapper.Map<StudentDto>(student);

            return Ok(studentToReturn);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("DeleteStudent/{studentId}")]
        public async Task<ActionResult> DeleteStudent(int studentId)
        {
            if (!await _studentService.StudentExistsAsync(studentId))
            {
                return NotFound($"Student with id {studentId} does not exist.");
            }

            try
            {
                await _studentService.DeleteStudent(studentId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok("Student was deleted successfully.");
        }
    }
}