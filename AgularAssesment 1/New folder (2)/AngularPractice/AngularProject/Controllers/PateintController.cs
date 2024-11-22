using App.core.App.Pateint.Command;
using App.core.Dto;
using App.Core.Apps.Pateint.Command;
using App.Core.Apps.Pateint.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PateintController : ControllerBase
    {
        private readonly IMediator mediator;

        public PateintController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PostPateint(PateintDto pateints)
        {
            var empid = await mediator.Send(new CreatePateintCommand { Pateint = pateints });
            return Ok(empid);
        }
        [HttpGet]
        public async Task<IActionResult> GetPateintList()
        {
            var employees = await mediator.Send(new GetPateintQuery());
            return Ok(employees);
        }       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPateintById(int id)
        {
            var employee = await mediator.Send(new GetPateintByIdQuery { Id = id });
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePateint(PateintDto pateints)
        {
            var emp = await mediator.Send(new UpdatePateintCommand { Pateint = pateints });
            return Ok(emp);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeletePateint(int id)
        {
            var employee = await mediator.Send(new DeletePateintCommand { Id = id });
                        return Ok(employee);
        }
    }
}
