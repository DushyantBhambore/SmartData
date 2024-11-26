using App.Core.Apps.Patient.Command;
using App.Core.Apps.Practitioner.Command;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PractitionerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddorUpdate(PractitionerDto practitionerDto)
        {
            var result = await _mediator.Send(new AddPractitionerCommand { PractitionerDto = practitionerDto });
            return Ok(result);
        }
    }
}
