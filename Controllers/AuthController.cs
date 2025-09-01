using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _authService.AuthenticateUser(loginRequest.Username, loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Credenciales incorrectas." });
            }

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }
    }
}
