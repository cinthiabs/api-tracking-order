using Application.DTO;
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
        private readonly IServiceTracking _service;
        public LoginController(IConfiguration Configuration, IServiceTracking service)
        {
            _config = Configuration;
            _service = service;
        }

        /// <param name="login">Teste</param>
        /// <returns>Return data</returns>
        /// <response code="200">Authenticated</response>
        /// <response code="400">Access denied!</response>
        /// <response code="500">Internal error please contact.</response>
        [ProducesResponseType(typeof(ReturnSucessDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReturnDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ReturnDTO), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO login)
        {
            try
            {
                bool result = await UserValidation(login);

                if (result)
                {
                    var tokenString = TokenJWT();
                    var returnSucess = new ReturnSucessDTO();
                    var nextToken = DateTime.Now.AddMinutes(60).ToString("yyyy-MM-ddTHH:mm:ss-ff:00");

                    returnSucess = new ReturnSucessDTO()
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
                    return Unauthorized(new ReturnDTO { Message = "Access denied!", Status  = 0 });
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
        private async Task<bool> UserValidation(UserDTO login)
        {
            var query = await _service.userQuery(login);
            var validation = query > 0;
            return validation;
        }
    }
}
