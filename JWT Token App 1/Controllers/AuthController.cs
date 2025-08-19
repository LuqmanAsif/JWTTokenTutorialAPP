using JWT_Token_App_1.Service;
using JWT_Token_App_1.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Token_App_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTTokenGenerator _jwtService;

        public AuthController(JWTTokenGenerator jwtService)
        {
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Username == "admin" && login.Password == "password")
            {
                var token = _jwtService.GenerateJwtToken(login.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
