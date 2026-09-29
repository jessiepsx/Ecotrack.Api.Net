using Moq;
using Microsoft.AspNetCore.Mvc;
using EcoTrack.Controllers;
using Ecotrack.Api.Net.Services;
using Ecotrack.Net.ViewModel;
using Xunit;

namespace Ecotrack.Tests
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _mockService;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mockService = new Mock<IAuthService>();
            _controller = new AuthController(_mockService.Object);
        }

        [Fact]
        public void Login_RetornaStatusCode200()
        {
            // Arrange
            var login = new LoginViewModel
            {
                Email = "admin@ecotrack.com",
                Senha = "123456"
            };

            _mockService.Setup(x => x.Authenticate(login))
                        .Returns("token_fake");

            // Act
            var result = _controller.Login(login);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(200, okResult.StatusCode ?? 200);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void Login_RetornaCredencialInvalida()
        {
            // Arrange
            var login = new LoginViewModel
            {
                Email = "errado@ecotrack.com",
                Senha = "senhaerrada"
            };

            _mockService.Setup(x => x.Authenticate(login))
                        .Returns((string)null);

            // Act
            var result = _controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}