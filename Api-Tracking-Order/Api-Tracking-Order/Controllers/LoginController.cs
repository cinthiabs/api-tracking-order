using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api_Tracking_Order.Controllers
{

    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IService _service;
        public LoginController(IConfiguration Configuration, IService service)
        {
            _config = Configuration;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO login)
        {
            try
            {
                bool result = await UserValidation(login);

                if (result)
                {
                    var tokenString = TokenJWT();
                    var data = new NextAccess();
                    var nextToken = DateTime.Now.AddMinutes(60).ToString("yyyy-MM-ddTHH:mm:ss-ff:00");

                    data = new NextAccess()
                    {
                        message = "Authenticated",
                        access_key = tokenString,
                        expire_at = nextToken
                    };
                    return Ok(new { message = "OK", status = 1, data });
                }
                else
                {
                    return Unauthorized(new ReturnDTO { message = "Access denied!", status  = 0 });
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error please contact.");
            }
        }
        private string TokenJWT()
        {
            var issuer = "Login";
            var audience = "full";
            _ = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("62Y3ZN33JVQWQDBWVSGQZBKZAYCPQ6"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        private async Task<bool> UserValidation(UserDTO login)
        {
            var consulta = await _service.userQuery(login);
            var validation = consulta > 0 ? true : false;
            return validation;
        }
    }
}
