using App.core.App.Employee.Command;
using App.core.Dto;
using App.Core.Apps.Employee.Command;
using App.Core.Apps.Employee.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeesController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDto employee)
        {
            var empid = await mediator.Send(new CreateEmployeeCommand { Emp = employee });
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
            var employee = await mediator.Send(new GetEmployeeByIdQuery { Id = id });
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employee)
        {
            var emp = await mediator.Send(new UpdateEmployeeCommand { Employee = employee });
            return Ok(emp);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Ok(employee);
        }
    }
}
