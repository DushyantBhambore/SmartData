using App.Core.Apps.Department.Command;
using App.Core.Apps.Department.Query;
using App.Core.Apps.Employee.Command;
using App.Core.Apps.Employee.Query;
using App.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EFModelBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCQRSController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeCQRSController(IMediator _mediator)
        {
           mediator = _mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDto  employee)
        {
            var empid = await mediator.Send(new CreateEmployeeCommand { Employee = employee });
            return Ok(empid);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var employees = await mediator.Send(new GetEmployeeQuery());
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await mediator.Send(new GeyEmployeeByIdQuery { Id = id });
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto employee)
        {
            var emp = await mediator.Send(new UpdateEmployeeCommand { Id = id, Employee = employee });
            return Ok(emp);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Ok(employee);
        }

    }
}
