using Microsoft.AspNetCore.Mvc;
using StudentProject.Model;

namespace StudentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> students = students = Enumerable.Range(1, 5).Select(index => new Student
        {
            Id = index + 1,
            Name = $"Student - {index + 1}"
        }).ToList();

        [HttpGet]
        public IActionResult Get()
        {    
            return StatusCode(StatusCodes.Status200OK,students);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            students.Add(student);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, Student student)
        {
            if(id != student.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var obj = students.FirstOrDefault(x => x.Id == id);
            if(obj is null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            obj.Name = student.Name;
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = students.FirstOrDefault(x=>x.Id == id);
            if (obj is null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            students.Remove(obj);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
