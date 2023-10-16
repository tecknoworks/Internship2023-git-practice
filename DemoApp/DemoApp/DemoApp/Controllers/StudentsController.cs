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

        public StudentsController(IStudentsService studentService)
        {
            _studentService = studentService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return Ok(await _studentService.GetStudentsAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetStudent/{studentId}", Name ="GetStudent")]
        public async Task<ActionResult<Student>> GetStudent(int studentId)
        {
            var student = await _studentService.GetStudentAsync(studentId);

            if (student == null)
            {
                return NotFound($"Student with id {studentId} does not exist.");
            }

            return Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreateStudent")]
        public async Task<ActionResult<Student>> CreateStudent(Student newStudent)
        {
            if (await _studentService.StudentExistsAsync(newStudent.Id))
            {
                return BadRequest($"Student with id {newStudent.Id} already exists.");
            }

            _studentService.CreateStudent(newStudent);

            return CreatedAtRoute("GetStudent", new { studentId = newStudent.Id }, newStudent);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("UpdateStudent/{studentId}")]
        public async Task<ActionResult> UpdateStudent(int studentId, Student updatedStudent) 
        {
            if (!await _studentService.StudentExistsAsync(studentId)) 
            {
                return NotFound($"Student with id {studentId} does not exist.");
            }

            _studentService.UpdateStudent(studentId, updatedStudent);

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("DeleteStudent/{studentId}")]
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