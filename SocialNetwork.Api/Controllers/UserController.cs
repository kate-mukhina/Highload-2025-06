using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (request.Gender != "Male" && request.Gender != "Female")
            {
                return BadRequest("Invalid gender. Use 'Male' or 'Female'.");
            }

            var result = await _userService.RegisterAsync(request);
            return result.Success ? Ok(result.UserId) : BadRequest(result.Error);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            return user != null ? Ok(user) : BadRequest("Пользователь не найден");
        }
    }
}
