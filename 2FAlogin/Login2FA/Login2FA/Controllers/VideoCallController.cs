using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTokSDK;

namespace Login2FA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VideoCallController : ControllerBase
    {
        private const string ApiKey = "1dea0a2c";
        private const string ApiSecret = "hOtsTKu46RyJJ8Ie";

        [HttpGet("credentials")]
        public IActionResult GetCredentials()
        {
            var opentok = new OpenTok(ApiKey, ApiSecret);
            var session = opentok.CreateSession();
            var token = session.GenerateToken();

            return Ok(new
            {
                ApiKey,
                SessionId = session.Id,
                Token = token
            });
        }
        [HttpPost("startRecording")]
        public IActionResult StartRecording([FromBody] string sessionId)
        {
            var opentok = new OpenTok(ApiKey, ApiSecret);
            var archive = opentok.StartArchive(sessionId, "Call Recording");
            return Ok(archive.Id);
        }

        [HttpPost("stopRecording")]
        public IActionResult StopRecording([FromBody] string archiveId)
        {
            var opentok = new OpenTok(ApiKey, ApiSecret);
            opentok.StopArchive(archiveId);
            return Ok();
        }


    }
}
