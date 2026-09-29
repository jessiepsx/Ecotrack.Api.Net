using Ecotrack.Api.Net.Models;
using Ecotrack.Api.Net.Services;
using Ecotrack.Api.Net.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecotrack.Api.Net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcaoController : ControllerBase
    {
        private readonly IAcaoService _service;

        public AcaoController(IAcaoService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get(
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanho = 10)
        {
            var acoes = _service.GetAll(pagina, tamanho);

            return Ok(acoes);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var acao = _service.GetById(id);

            if (acao == null)
                return NotFound();

            return Ok(acao);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AcaoCreateViewModel viewModel)
        {
            var acao = new Acao
            {
                Titulo = viewModel.Titulo,
                Descricao = viewModel.Descricao,
                Pontos = viewModel.Pontos
            };

            _service.Add(acao);

            return CreatedAtAction(
                nameof(GetById),
                new { id = acao.Id },
                acao);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(
            int id,
            [FromBody] AcaoCreateViewModel viewModel)
        {
            var acao = _service.GetById(id);

            if (acao == null)
                return NotFound();

            acao.Titulo = viewModel.Titulo;
            acao.Descricao = viewModel.Descricao;
            acao.Pontos = viewModel.Pontos;

            _service.Update(acao);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var acao = _service.GetById(id);

            if (acao == null)
                return NotFound();

            _service.Delete(id);

            return NoContent();
        }
    }
}