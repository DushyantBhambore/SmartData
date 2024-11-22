using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static List<Student> students;
        private readonly IStudentService service;

        public StudentsController(IStudentService service)
        {
            this.service = service;
        }

       
        [HttpGet]
        public IActionResult GetStudent()
        {
           
            return Ok(service.GetStudents());
        }

        [HttpPost]
        public IActionResult PostStudent(Student student )
        {
           
            if(!ModelState.IsValid)
            {
                return BadRequest();
                     
            }
            service.PostStudent(student);
            return Ok();
            
        }

        private void If(bool isValid)
        {
            throw new NotImplementedException();
        }

        //static StudentsController()
        //{
        //    //IStudentService service = new StudentService(new FilePathHelper());
        //    students = service.GetStudents();
        //}
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(students);
        //}


        //[HttpPost]
        //public IActionResult Post(Student student)
        //{
        //    students.Add(student);

        //    return Created();
        //}

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            if (id != student.Id)
                return NotFound();

            var obj = students.FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return NotFound();


            obj.Name = student.Name;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        { 
            var obj = students.FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return NotFound();

            students.Remove(obj);

            return Ok();
        }
    }
}
