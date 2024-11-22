using App.Core.Apps.Course.Command;
using App.Core.Apps.Department.Command;
using App.Core.Apps.Department.Query;
using App.Core.Apps.Employee.Command;
using App.Core.Model;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFModelBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDto department)
        {
            var deptid = await mediator.Send(new CreateDeparmentCommand { Department = department });
            return Ok(deptid);
        }
        [HttpGet]
        public async Task<IActionResult> GetDeparmentList()
        {
            var deptid = await mediator.Send(new GetDepartmentQuery());
            return Ok(deptid);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeparmentById(int id)
        {
            var deptid = await mediator.Send(new GetDepartmentByIdQuery { Id = id});
            return Ok(deptid);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(int id,DepartmentDto department)
        {
            var deptid = await mediator.Send(new UpdateDepartmentCommand { Id = id ,Department =department});
            return Ok(deptid);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deptid = await mediator.Send(new DeleteDepartmentIdCommand { Id = id});
            return Ok(deptid);
        }
    }
}
