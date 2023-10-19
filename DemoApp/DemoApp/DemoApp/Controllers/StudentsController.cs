using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentLogicService _studentService;


        public StudentsController(IStudentLogicService studentService)
        {
            this._studentService = studentService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPost]

        public async Task<ActionResult<Student>> CreateNewStudent(int personId,Student student)
        {
            try
            {
                await _studentService.CreateStudentLogic(personId, student);
                return Ok("added new person");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]

        public async Task<IList> GetStudents()
        {
            try
            {
                return await _studentService.GetAllStudentsLogic(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentById(int id)
        {
            try
            {
                await _studentService.DeleteStudentLogic(id);
                return Ok("Student deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}