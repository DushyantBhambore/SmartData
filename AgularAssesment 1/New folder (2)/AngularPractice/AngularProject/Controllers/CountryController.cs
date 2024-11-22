using App.core.App.Employee.Command;
using App.Core.Apps.Employee.Command;
using App.Core.Apps.Employee.Query;
using App.core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.core.App.Country.Command;
using App.Core.Apps.Country.Command;
using App.Core.Apps.Country.Query;

namespace AngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CountryController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PostCountry(CountryDto country)
        {
            var empid = await mediator.Send(new CreateCountryrCommand { Country = country });
            return Ok(empid);
        }
        [HttpGet]
        public async Task<IActionResult> GetCountryList()
        {
            var employees = await mediator.Send(new GetCountryQuery());
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var employee = await mediator.Send(new GetCountryByIdQuery { Id = id });
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCountry(CountryDto country)
        {
            var emp = await mediator.Send(new UpdateCountryCommand { Country = country });
            return Ok(emp);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var employee = await mediator.Send(new DeleteCountryCommand { Id = id });
            return Ok(employee);
        }
    }
}
