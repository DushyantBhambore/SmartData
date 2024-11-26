using App.Core.Apps.Patient.Command;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddorUpdate(PatientDto patientDto)
        {
            var result = await _mediator.Send(new AddPatientCommand { patientDto = patientDto });
            return Ok(result);
        }
    }
}
