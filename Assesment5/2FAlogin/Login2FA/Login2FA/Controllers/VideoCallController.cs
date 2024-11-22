using EllipticCurve;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTokSDK;
using System;

namespace Login2FA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoCallController : ControllerBase
    {
        private const string ApiKey = "b669c86a";
        private const string ApiSecret = "EmUl7En92bICAKul";
        private const string APPId = "e753557c-65f5-4995-9c34-8bb2734a8372";
        private const string PrivateKeyPath = "D:\\Assesment5\\2FAlogin\\PrivateKey\\private.key"; // Path to your private key file

        [HttpGet("credentials")]
        public IActionResult GetCredentials()
        {
            var opentok = new OpenTok(APPId, PrivateKeyPath);
            var session = opentok.CreateSession(string.Empty,OpenTokSDK.MediaMode.ROUTED);
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
