using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Models;
using BusinessLayer.Services;
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
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{studentId}", Name ="GetStudent")]
        public async Task<ActionResult<StudentDto>> GetStudent(int studentId)
        {
            var student = await _studentService.GetStudentAsync(studentId);

            if (student == null)
            {
                return NotFound($"Student with id {studentId} does not exist.");
            }

            return Ok(_mapper.Map<StudentDto>(student));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<StudentDto> CreateStudent(StudentForCreationDto newStudent)
        {
            var student = _mapper.Map<Student>(newStudent);

            _studentService.CreateStudent(student);

            var studentToReturn = _mapper.Map<StudentDto>(student);

            return CreatedAtRoute("GetStudent", new { studentId = studentToReturn.Id }, studentToReturn);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{studentId}")]
        public async Task<ActionResult> UpdateStudent(int studentId, StudentForUpdateDto updatedStudent) 
        {
            var studentToUpdate = await _studentService.GetStudentAsync(studentId);
            
            if (studentToUpdate == null) 
            {
                return NotFound($"Student with id {studentId} does not exist.");
            }

            _mapper.Map(updatedStudent, studentToUpdate);

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{studentId}")]
        public async Task<ActionResult> DeleteStudent(int studentId)
        {
            if (!await _studentService.StudentExistsAsync(studentId))
            {
                return NotFound($"Student with id {studentId} does not exist.");
            }

            _studentService.DeleteStudent(studentId);

            return NoContent();
        }
    }
}