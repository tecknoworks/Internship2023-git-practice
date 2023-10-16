using BusinessLayer.Models;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService studentService;

        public StudentsController(IStudentsService studentService)
        {
            this.studentService = studentService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/allstudent")]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            return Ok(studentService.GetUsers());
        }


        [HttpGet("/{id}")]
        public async Task<ActionResult<Student>> GetStudentByID(int id)
        {
            try
            {
                return Ok(studentService.GetStudentByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //detele user
        [HttpDelete("/{id}")]
        public ActionResult DelateStudent(int id)
        {
            try
            {
                studentService.DelateStudent(id);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Deleted succesfully.");
            
        }

        //create user 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("/students")]
        public Student CreateStudent(Student student)
        {
           return studentService.CreateStudent(student);
        }

        //update user

        [HttpPut("/{id}")]
        public Student UpdateStudent(Student updatedStudent, int id)
        {
            return studentService.UpdateStudent(updatedStudent, id);
        }
    }
}