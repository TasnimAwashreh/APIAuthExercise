using API_AuthExcercise.API.Models;
using API_AuthExcercise.API.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_AuthExcercise.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly JwtTokenGenerator _jwtGenerator;

        public AuthController(JwtTokenGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginRequest userReq)
        {
            try
            {
                var token = _jwtGenerator.GenerateToken(userReq.Username, userReq.Password);
                return Ok(token);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpPost("validate")]
        public ActionResult Validate(TokenRequest tokenReq)
        {
            try
            {
                bool isValid = _jwtGenerator.ValidateToken(tokenReq.Token);
                return Ok(new { valid = isValid });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
