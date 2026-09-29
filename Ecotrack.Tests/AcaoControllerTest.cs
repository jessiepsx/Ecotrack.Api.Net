using Ecotrack.Api.Net.Controllers;
using Ecotrack.Api.Net.Models;
using Ecotrack.Api.Net.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Ecotrack.Tests
{
    public class AcaoControllerTests
    {
        private readonly Mock<IAcaoService> _mockService;
        private readonly AcaoController _controller;

        public AcaoControllerTests()
        {
            _mockService = new Mock<IAcaoService>();
            _controller = new AcaoController(_mockService.Object);
        }

        [Fact]
        public void Get_ReturnsStatusCode200()
        {
            // Arrange
            var acoes = new List<Acao>
            {
                new Acao
                {
                    Id = 1,
                    Titulo = "Reciclar",
                    Descricao = "Separar lixo",
                    Pontos = 10
                }
            };

            _mockService.Setup(s => s.GetAll(1, 10))
                        .Returns(acoes);

            // Act
            var result = _controller.Get(1, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode ?? 200);
        }
    }
}