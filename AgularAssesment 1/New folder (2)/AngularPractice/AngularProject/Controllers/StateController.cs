using App.core.App.Employee.Command;
using App.Core.Apps.Employee.Command;
using App.Core.Apps.Employee.Query;
using App.core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.core.App.State.Command;
using App.Core.Apps.State.Query;
using App.core.App.Customer.Command;
using App.Core.Apps.Customer.Command;

namespace AngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator mediator;

        public StateController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PostState(StateDto state)
        {
            var empid = await mediator.Send(new CreateStateCommand { State = state });
            return Ok(empid);
        }
        [HttpGet]
        public async Task<IActionResult> GetStateList()
        {
            var employees = await mediator.Send(new GetStateQuery());
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            var employee = await mediator.Send(new GetStateByIdQuery { Id = id });
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateState(StateDto state)
        {
            var emp = await mediator.Send(new UpdateStateCommand { State = state });
            return Ok(emp);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var employee = await mediator.Send(new DeleteStateCommand { Id = id });
            return Ok(employee);
        }
    }
}
