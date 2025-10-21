using API_AuthExcercise.API.Models;
using API_AuthExcercise.API.Requests;
using API_AuthExcercise.API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_AuthExcercise.API.Controllers
{
    [ApiController]
    [Route("auth")]
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
                return Ok(new UserLoginResponse { Token = token });
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
                return Ok(new ValidationResponse{ Valid = isValid });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
