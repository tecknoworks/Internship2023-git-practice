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
            try
            {
                return Ok(await studentService.GetUsers());
            }catch (Exception) {
                throw;
            }
            
        }


        [HttpGet("/{id}")]
        public async Task<ActionResult<Student?>> GetStudentByID(int id)
        {
            try
            {
                return Ok(await studentService.GetStudentByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //detele user
        [HttpDelete("/{id}")]
        public async Task<ActionResult>  DelateStudent(int id)
        {
            try
            {
                await studentService.DelateStudent(id);
                return Ok("Deleted succesfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            
        }

        //create user 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("/students")]
        public async Task<Student> CreateStudent(Student student)
        {
            try
            {
                return await studentService.CreateStudent(student);
            }catch (Exception )
            {
                throw;
            }
           
        }

        //update user

        [HttpPut("/{id}")]
        public async Task<Student> UpdateStudent(Student updatedStudent, int id)
        {
            try
            {
                return await studentService.UpdateStudent(updatedStudent, id);
            }
            catch
            {
                throw;
            }
            
        }
    }
}