using App.Core.Apps.Patient.Command;
using App.Core.Apps.Patient.Query;
using App.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgentPatietntDashboard.Controllers
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

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto patientDto)
        {
            var result = await _mediator.Send(new AddPatientCommand { patientDto = patientDto });
            return Ok(result);
        }

        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            var result = await _mediator.Send(new GetAllPatientQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await _mediator.Send(new GetPatientByIdQuery { id = id });
            return Ok(result);
        }

        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientDto patientDto)
        {
            var result = await _mediator.Send(new UpdatePatientCommand { patientDto = patientDto });
            return Ok(result);
        }

        [HttpDelete("[action]/{id}")] 
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _mediator.Send(new DeletePatientCommand { id = id });
            return Ok(result);
        }

    }
}
