using Code_First_Approach.Data.Entities;
using Code_First_Approach.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code_First_Approach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourses coursesServices;

        public CoursesController(ICourses _coursesServices)
        {
            coursesServices = _coursesServices;
        }

        [HttpPost]
        public IActionResult AddCourse(Courses courses)
        {
            coursesServices.AddCourse(courses);
            return Ok(courses);
        }

        [HttpGet]
        public IActionResult CourseList()
        {

            return Ok(coursesServices.CourseList());
        }
    }
}
