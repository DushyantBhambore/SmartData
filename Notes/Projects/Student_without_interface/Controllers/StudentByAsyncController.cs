using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_without_interface.Model;
using Student_without_interface.StudentServices;

namespace Student_without_interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentByAsyncController : ControllerBase
    {
        private readonly StudentRepository services;

        public StudentByAsyncController(StudentRepository services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {

            return Ok(await services.GetAllStudent());
        }

        [HttpPost]

        public async Task<IActionResult> PostStudent(Student student)
        {
            await services.GetStudent(student);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var obj =await services.GetStudentByIdAsync(id);
            return Ok(obj);
        }


        //[HttpDelete ]

        //public async Task 

      
    }
}
