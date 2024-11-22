using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_without_interface.StudentServices;

namespace Student_without_interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices services;

        public StudentController(IStudentServices _services)
        {
            services = _services;
        }

        [HttpGet]
        public IActionResult 
    }
}
