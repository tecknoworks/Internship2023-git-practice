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

        public async Task<ActionResult<string>> CreateNewStudent(int personId,Student student)
        {
            try
            {
                return await _studentService.CreateStudentLogic(personId, student);
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
        public async Task<ActionResult<string>> DeleteStudentById(int id)
        {
            try
            {
                return await _studentService.DeleteStudentLogic(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}