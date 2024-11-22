using JwtWebApiDotNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OpenTokSDK;
using System;

namespace JwtWebApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly OpenTok _openTok; // OpenTok instance

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;

            // Get the API Key from configuration
            string apiKey = _configuration["OpenTok:ApiKey"];

            // Use the ApiKeyHasher to hash the API key
            int hashedApiKey = ApiKeyHasher.ConvertToInt(apiKey);

            // Log or use the hashed API key (here just for demonstration)
            Console.WriteLine($"Hashed API Key: {hashedApiKey}");

            // Initialize OpenTok with hashed API Key and Secret
            string apiSecret = _configuration["OpenTok:ApiSecret"];
            string privatekey = _configuration["OpenTok:privatekey"];
            string applicationId = _configuration["OpenTok:applicationId"];

            _openTok = new OpenTok(hashedApiKey, apiSecret);

            // Optionally set a custom user agent
            _openTok.SetCustomUserAgent("MyCustomApp");
        }

        [HttpPost("register")]
        [Authorize]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Email = request.Email;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }

        [HttpPost("login")]
        [Authorize]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.Email != request.Email)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }
            string token = CreateToken(user);

            return Ok(token);
        }

        [HttpGet("generate-session")]
        public ActionResult<string> GenerateSession()
        {
            try
            {
                // Create a new OpenTok session
                var session = _openTok.CreateSession();
                return Ok(session.Id); // Return the session ID
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("generate-token/{sessionId}")]
        public ActionResult<string> GenerateToken(string sessionId)
        {
            try
            {
                // Convert DateTime to Unix timestamp
                double expireTime = ((DateTimeOffset)DateTime.UtcNow.AddHours(1)).ToUnixTimeSeconds();

                // Generate the token
                var token = _openTok.GenerateToken(sessionId,
                    role: Role.PUBLISHER, // Set the role
                    expireTime: expireTime // Pass the Unix timestamp
                );

                return Ok(token); // Return the generated token
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Corrected algorithm

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
