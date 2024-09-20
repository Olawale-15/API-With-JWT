using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolNewApi.DTOs;
using SchoolNewApi.Interface;

namespace SchoolNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var getStudent = _studentService.GetStudents();
            return Ok(getStudent);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Register(CreateStudentRequestModel model)
        {
            var createStudent = _studentService.CreateStudent(model);
            if (createStudent != null)
            {
                return Ok(createStudent);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id) {
            var getStudent = _studentService.GetStudent(id);
            if (getStudent != null)
            {
                return Ok(getStudent);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentRequestModel model)
        {
            var updateStudent = _studentService.UpdateStudent(id, model);
            if (updateStudent != null)
            {
                return Ok(model);
            }
            else
            {

               return BadRequest(); 
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id) { 
            var deleteStudent = _studentService.DeleteStudent(id);
            if(deleteStudent != null)
            {
                return Ok("student sucessfuly deleted");
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}
