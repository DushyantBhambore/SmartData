using Code_First_Approach.Data.Entities;
using Code_First_Approach.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code_First_Approach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent studentservices;

        public StudentController(IStudent _studentservices)
        {
            studentservices = _studentservices;
        }

        [HttpPost]
        public IActionResult AddStudent(Student student )
        {
            studentservices.AddStudent(student);
            return Ok(student);
        }

        [HttpGet]
        public IActionResult ListStudent()
        {
            return Ok(studentservices.GetAllStudent());
        }
    }
}
