using App.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Login2FA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenTokController : ControllerBase
    {
        private readonly OpenTokService _openTokService;

        public OpenTokController(OpenTokService openTokService)
        {
            _openTokService = openTokService;
        }

        [HttpGet("create-session")]
        public IActionResult CreateSession()
        {
            var sessionId = _openTokService.CreateSession();
            return Ok(new { sessionId });
        }

        [HttpGet("generate-token")]
        public IActionResult GenerateToken([FromQuery] string sessionId)
        {
            var token = _openTokService.GenerateToken(sessionId);
            return Ok(new { token });
        }

        [HttpPost("start-recording")]
        public IActionResult StartRecording([FromBody] string sessionId)
        {
            var archive = _openTokService.StartRecording(sessionId);
            return Ok(new { archiveId = archive.Id });
        }

        [HttpPost("stop-recording")]
        public IActionResult StopRecording([FromBody] string archiveId)
        {
            _openTokService.StopRecording(archiveId);
            return Ok(new { message = "Recording stopped successfully" });
        }

    }
}




