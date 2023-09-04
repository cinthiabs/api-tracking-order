using Api_Tracking_Order.Controllers;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Application.Interface;
using Microsoft.Extensions.Configuration;
using Service.Interface;
using AutoMapper;

namespace Login
{
    public class LoginControllerTests 
    {
        private readonly LoginController _login;
        private readonly Application.Service.ServiceTracking _service;
        private readonly Mock<IServiceTracking> _mockServiceTracking;
        public LoginControllerTests()
        {
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.SetupGet(x => x["Jwt:Issuer"]).Returns("Test");
            mockConfiguration.SetupGet(x => x["Jwt:Audience"]).Returns("full");
            mockConfiguration.SetupGet(x => x["Jwt:Key"]).Returns("C45EBC4DEFAB11A4EE888E");

            _mockServiceTracking = new Mock<IServiceTracking>();
            var registration = new Mock<IRegistration>();
            var mockMapper = new Mock<IMapper>();

            _login = new LoginController(mockConfiguration.Object, _mockServiceTracking.Object);
            _service = new Application.Service.ServiceTracking(registration.Object, mockMapper.Object);
        }

        [Fact (DisplayName = "Given valid data, when generate token then authorized")]
        public async Task  Login_ValidUser_ReturnsOk()
        {
            // Arrange
            var UserDTO = new UserDTO
            {
                User = "UserTest",
                Password = "F854@5"
            };
            // Configurar o mock de IServiceTracking para return 1
            _mockServiceTracking.Setup(service => service.userQuery(UserDTO))
                               .ReturnsAsync(1);

            // Act
            var result = await _login.Login(UserDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnSucess = Assert.IsType<ReturnSucessDTO>(okResult.Value);
            Assert.Equal("OK", returnSucess.Message);
            Assert.Equal(200, returnSucess.Status);
            Assert.Equal("Authenticated", returnSucess.Data.Message);
            Assert.NotNull(returnSucess.Data.Access_key);
            Assert.NotNull(returnSucess.Data.expire_at);
        }

        [Fact(DisplayName = "Given invalid data, when generate token then Unauthorized")]
        public async Task Login_InvalidUser_ReturnsUnauthorized()
        {
            // Arrange
            var UserDTO = new UserDTO
            {
                User = "User",
                Password = "password"
            };
            //Configurando o mock do IServiceTracking para return 0
            _mockServiceTracking.Setup(service => service.userQuery(UserDTO))
                               .ReturnsAsync(0);
            //  Act
            var result = await _login.Login(UserDTO);

            //    Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var returnDTO = Assert.IsType<ReturnDTO>(unauthorizedResult.Value);
            Assert.Equal("Access denied!", returnDTO.Message);
            Assert.Equal(0, returnDTO.Status);
        }

        [Fact(DisplayName = "Given an exception, when generate token then InternalServerError")]
        public async Task Login_Exception_ReturnsError()
        {
            // Arrange
            var UserDTO = new UserDTO
            {
                User = "User",
                Password = "password"
            };

            // Configurando o mock do IServiceTracking para return exception
            _mockServiceTracking.Setup(service => service.userQuery(UserDTO))
                               .Throws(new Exception("Simulated exception"));

            // Act
            var result = await _login.Login(UserDTO);

            // Assert
            var internalServerErrorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, internalServerErrorResult.StatusCode);
            Assert.Equal("Internal error please contact.", internalServerErrorResult.Value);
        }
    }
}