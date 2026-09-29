using Moq;
using Microsoft.AspNetCore.Mvc;
using Ecotrack.Api.Net.Controllers;
using Ecotrack.Api.Net.Services;
using Ecotrack.Api.Net.ViewModel;
using Xunit;

namespace Ecotrack.Tests
{
    public class DicaControllerTests
    {
        private readonly Mock<IDicaService> _mockService;
        private readonly DicaController _controller;

        public DicaControllerTests()
        {
            _mockService =
                new Mock<IDicaService>();

            _controller =
                new DicaController(
                    _mockService.Object);
        }

        [Fact]
        public async Task Get_ReturnsStatusCode200()
        {
            var resultado =
                new PagedResult<DicaViewModel>();

            _mockService
                .Setup(x =>
                    x.ListarAsync(1, 10, null))
                .ReturnsAsync(resultado);

            var result =
                await _controller.Listar(
                    1,
                    10,
                    null);

            var okResult =
                Assert.IsType<OkObjectResult>(
                    result);

            Assert.Equal(
                200,
                okResult.StatusCode ?? 200);
        }
    }
}