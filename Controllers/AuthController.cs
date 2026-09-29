using Ecotrack.Api.Net.Services;
using Ecotrack.Net.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login(
            [FromBody] LoginViewModel login)
        {
            var token = _service.Authenticate(login);

            if (token == null)
            {
                return Unauthorized(new
                {
                    mensagem = "Email ou senha inválidos"
                });
            }

            return Ok(new
            {
                token = token
            });
        }
    }
}