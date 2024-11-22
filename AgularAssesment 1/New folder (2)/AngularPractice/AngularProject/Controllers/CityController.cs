using App.core.App.Employee.Command;
using App.Core.Apps.Employee.Command;
using App.Core.Apps.Employee.Query;
using App.core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.core.App.City.Command;
using App.Core.Apps.City.Query;
using App.Core.Apps.City.Command;

namespace AngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator mediator;

        public CityController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PostCity(CityDto City)
        {
            var city = await mediator.Send(new CreateCityCommand { City = City });
            return Ok(city);
        }
        [HttpGet]
        public async Task<IActionResult> GetCityList()
        {
            var city = await mediator.Send(new GetCityQuery());
            return Ok(city);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await mediator.Send(new GetCityByIdQuery { Id = id });
            return Ok(city);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCity(CityDto city)
        {
            var cityupdate = await mediator.Send(new UpdateCityCommand { City = city });
            return Ok(cityupdate);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var citydelete = await mediator.Send(new DeleteCityCommand { Id = id });
            return Ok(citydelete);
        }
    }
}
