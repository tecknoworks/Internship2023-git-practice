using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherLogicService _teacherService;

        public TeacherController(ITeacherLogicService teacherService)
        {
            _teacherService = teacherService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPost]

        public async Task<ActionResult<string>> CreateNewTeacher(int personId, Teacher teacher)
        {
            try
            {
                return await _teacherService.CreateTeacherLogic(personId, teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IList> GetTeachers()
        {
            try
            {
                return await _teacherService.GetAllTeachersLogic();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
