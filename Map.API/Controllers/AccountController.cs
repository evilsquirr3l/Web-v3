using System.Threading.Tasks;
using Business.Abstraction;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Map.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Sign In")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _userService.Login(model);

            if (token == null)
            {
                return BadRequest(new {message = "Username or password is incorrect"});
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("Sign Up")]
        public async Task<object> Register([FromBody] UserRegistrationModel model)
        {
            var token = await _userService.Register(model);

            return Ok(token);
        }
    }
}