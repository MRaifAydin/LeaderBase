using LeaderBase.Business.Auth.Abstract;
using LeaderBase.Core.Auth.Entities;
using LeaderBase.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LeaderBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public static User test = new User();

        [HttpGet, Authorize]
        public ActionResult<object> Get()
        {
            var userName = User?.Identity?.Name;
            var userName2 = User.FindFirstValue(ClaimTypes.Name);
            var role = User.FindFirstValue(ClaimTypes.Role);
            return Ok(new { userName, userName2, role });
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] UserDto user)
        {
            _userService.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwardSalt);
            test.PasswordHash = passwordHash;
            test.PasswordSalt = passwardSalt;
            test.Username = user.Username;
            return Ok(test);
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] UserDto user)
        {
            _userService.CreateToken(test);
            if (user.Username != test.Username)
            {
                return BadRequest("User not exist.");
            }
            else if (!_userService.VerifyPasswordHash(user.Password, test.PasswordHash, test.PasswordSalt))
            {

                return BadRequest("Password not correct.");
            }
            else
            {
                return Ok(_userService.CreateToken(test));
            }
        }
    }
}
