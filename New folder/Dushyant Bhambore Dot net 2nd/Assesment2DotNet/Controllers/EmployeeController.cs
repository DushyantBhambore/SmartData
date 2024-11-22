using Assesment2DotNet.Interface;
using Assesment2DotNet.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment2DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee services;

        public EmployeeController(IEmployee _services)
        {
            services = _services;
        }
        [HttpPost("/AddEmployee")]
        public IActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                services.AddEmployee(model);
                return Created();
            }
            return BadRequest();
        }
        [HttpGet("/GetEmployeeLis")]
        public IActionResult GetEmployeeLis()
        {
            return Ok(services.GetEmployeeList());
        }
        [HttpGet("/GetEmployeeGetById")]
        public IActionResult GetEmployeeGetById(int id)
        {
            services.GetEmployee(id);
            return Ok();
        }

        [HttpPost("/UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }
            services.UpdateEmployee(model);
            return Ok();
        }

        [HttpPost("/DeleteEmployee")]
        public IActionResult RemoveEmployee(int id)
        {
            if (ModelState.IsValid)
            {
                services.DeleteEmployee(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
