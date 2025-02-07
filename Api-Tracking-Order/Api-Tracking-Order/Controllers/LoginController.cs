using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api_Tracking_Order.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IApplicationTracking _application;
        public LoginController(IConfiguration Configuration, IApplicationTracking application)
        {
            _config = Configuration;
            _application = application;
        }

        /// <param name="login">Teste</param>
        /// <returns>Return data</returns>
        /// <response code="200">Authenticated</response>
        /// <response code="400">Access denied!</response>
        /// <response code="500">Internal error please contact.</response>
        [ProducesResponseType(typeof(ReturnSucessDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReturnDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ReturnDto), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDto login)
        {
            try
            {
                bool result = await UserValidation(login);

                if (result)
                {
                    var tokenString = TokenJWT();
                    var returnSucess = new ReturnSucessDto();
                    var nextToken = DateTime.Now.AddMinutes(60).ToString("yyyy-MM-ddTHH:mm:ss-ff:00");

                    returnSucess = new ReturnSucessDto()
                    {
                        Message = "OK",
                        Status = 200,
                        Data = new()
                        {
                            Message = "Authenticated",
                            Access_key = tokenString,
                            expire_at = nextToken
                        }
                    };
                   
                    return Ok(returnSucess);
                }
                else
                {
                    return Unauthorized(new ReturnDto { Message = "Access denied!", Status  = 0 });
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error please contact.");
            }
        }
        private string TokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(60);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: expires,
                signingCredentials: credentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
        private async Task<bool> UserValidation(UserDto login)
        {
            var query = await _application.UserQuery(login);
            var validation = query > 0;
            return validation;
        }
    }
}
