using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Services;

namespace SocialNetwork.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var authResult = await _authService.AuthenticateAsync(request.Username, request.Password);
            return authResult.Success ? Ok(new { UserId = authResult.UserId }) : Unauthorized();
        }
    }
}
