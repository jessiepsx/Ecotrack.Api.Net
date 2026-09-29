using Moq;
using Microsoft.AspNetCore.Mvc;
using Ecotrack.Net.Controllers;
using Ecotrack.Api.Net.Services;
using Ecotrack.Net.Models;

namespace Ecotrack.Tests
{
    public class UsuarioControllerTests
    {
        private readonly Mock<IUsuarioService> _mockService;
        private readonly UsuarioController _controller;

        public UsuarioControllerTests()
        {
            _mockService = new Mock<IUsuarioService>();
            _controller = new UsuarioController(_mockService.Object);
        }

        [Fact]
        public void Get_Retorna_Ok()
        {
            // Arrange
            var usuarios = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    Nome = "Jessica",
                    Email = "jessica@ecotrack.com"
                }
            };

            _mockService.Setup(x => x.GetAll(1, 10))
                        .Returns(usuarios);

            // Act
            var result = _controller.Get(1, 10);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Usuario>>>(result);

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            Assert.Equal(200, okResult.StatusCode ?? 200);
        }
    }
}