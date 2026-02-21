using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using practicing.Application.Services;
using practicing.Domain.Dtos;

namespace practicing.Controllers
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

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            if(await _authService.UserExist(request.Username))
            {
                return BadRequest("User already exists");
            }

            var user = new IdentityUser
            {
                UserName = request.Username
            };

            var defaultRole = "User";
            try
            {
                await _authService.Register(user, request.Password, defaultRole);
                return Ok(new { user.Id, user.UserName, defaultRole });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var token = await _authService.Login(request.Username, request.Password);
            if(token == null)
            {
                return BadRequest("Username or Password is incorrect");
            }
            return Ok(new { token, expires = DateTime.Now.AddDays(1) });
        }
    }
}
