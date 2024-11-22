using Code_First_Approach.Data.Entities;
using Code_First_Approach.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code_First_Approach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly Iinstructor iinstructorService;

        public InstructorController(Iinstructor _iinstructorService)
        {
            iinstructorService = _iinstructorService;
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructors model)
        {
            iinstructorService.AddInstructors(model);
            return Ok(model);
        }

        [HttpGet]
        public IActionResult InstructorList()
        {
            return Ok(iinstructorService.instructorsList());
        }
    }
}
