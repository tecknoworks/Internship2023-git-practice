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
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            //TODO:
            //Implement the method to return the list of students
            return await studentService.GetUsers();
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            return await studentService.GetUsersById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await studentService.DeleteUserById(id);
            return Ok("Successfully deleted!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateById(int id, Student student)
        {
            await studentService.UpdateUserById(id, student);
            return Ok("Successfully updated!");
        }

        [HttpPost]

        public async Task<ActionResult<List<Student>>> Add(Student student)
        {
            studentService.AddNewUser(student);
            return Ok(await Get());
        }
    }
}