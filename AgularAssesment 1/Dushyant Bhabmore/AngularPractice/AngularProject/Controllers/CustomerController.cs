using App.core.App.Customer.Command;
using App.Core.Apps.Customer.Command;
using App.Core.Apps.Customer.Query;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;
        public CustomerController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PostCustomer(Customers customer)
        {
            var empid = await mediator.Send(new CreateCustomerCommand { Customer = customer });
            return Ok(empid);
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var employees = await mediator.Send(new GetCustomerQuery());
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var employee = await mediator.Send(new GeyCustomerByIdQuery { Id = id });
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Domain.Customers customer)
        {
            var emp = await mediator.Send(new UpdateCustomerCommand { Customer = customer });
            return Ok(emp);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var employee = await mediator.Send(new DeleteCustomerCommand { Id = id });
            return Ok(employee);
        }
    }
}
