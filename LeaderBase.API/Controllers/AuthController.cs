using LeaderBase.Business.Abstract;
using LeaderBase.DTO.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginDto userLoginDto)
        {
            var loginEntity = _authService.Login(userLoginDto);

            if (!loginEntity.Success)
            {
                return BadRequest(loginEntity.Message);
            }

            var result = _authService.CreateAccessToken(loginEntity.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userRegisterDto)
        {
            var userExist = _authService.UserExist(userRegisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult = _authService.Register(userRegisterDto, userRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
