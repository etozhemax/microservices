using Microservices.Authentication.Api.Dtos;
using Microservices.Authentication.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await _authService.Login(request);

            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var response = await _authService.Register(request);

            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("assign")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterRequestDto request)
        {
            var isAssignedRole = await _authService.AssignRole(request);

            if (isAssignedRole == null || !isAssignedRole.Success)
            {
                return BadRequest();
            }

            return Ok(isAssignedRole);
        }
    }
}
