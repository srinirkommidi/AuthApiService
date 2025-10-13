using LogInAuthService.Models;
using LogInAuthService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogInAuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
                _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials creds)
        {
            // Demo: validate against hard-coded user. Replace with DB/Identity in real apps.
            if (creds is null || creds.Username != "admin" || creds.Password != "admin123")
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var token = _tokenService.GenerateToken(creds.Username);
            return Ok(new { access_token = token, token_type = "Bearer", expires_in_minutes = 60 });
        }

        // GET: api/<AuthController>
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value : " + id.ToString();
        }

        // POST api/<AuthController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
