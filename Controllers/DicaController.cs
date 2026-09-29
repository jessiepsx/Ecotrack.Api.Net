using Ecotrack.Api.Net.Services;
using Ecotrack.Api.Net.ViewModel;
using Ecotrack.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecotrack.Api.Net.Controllers
{
    [ApiController]
    [Route("dicas-esg")]
    [Produces("application/json")]
    public class DicaController : ControllerBase
    {
        private readonly IDicaService _service;

        public DicaController(IDicaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas as dicas ESG com paginação e filtro opcional por categoria.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PagedResult<DicaViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(
            [FromQuery] int pagina = 1,
            [FromQuery] int itensPorPagina = 10,
            [FromQuery] CategoriaDica? categoria = null)
        {
            var resultado = await _service.ListarAsync(pagina, itensPorPagina, categoria);
            return Ok(resultado);
        }

        /// <summary>
        /// Retorna uma dica ESG pelo ID.
        /// </summary>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DicaViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var dica = await _service.BuscarPorIdAsync(id);
            if (dica == null)
                return NotFound(new { mensagem = $"Dica com ID {id} não encontrada." });

            return Ok(dica);
        }

        /// <summary>
        /// Cria uma nova dica ESG. (Requer autenticação)
        /// </summary>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(DicaViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromBody] DicaCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var criada = await _service.CriarAsync(viewModel);
            return CreatedAtAction(nameof(BuscarPorId), new { id = criada.Id }, criada);
        }

        /// <summary>
        /// Atualiza uma dica ESG existente. (Requer autenticação)
        /// </summary>
        [HttpPut("{id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(DicaViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Atualizar(int id, [FromBody] DicaCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var atualizada = await _service.AtualizarAsync(id, viewModel);
            if (atualizada == null)
                return NotFound(new { mensagem = $"Dica com ID {id} não encontrada." });

            return Ok(atualizada);
        }

        /// <summary>
        /// Remove uma dica ESG (soft delete). (Requer autenticação)
        /// </summary>
        [HttpDelete("{id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletar(int id)
        {
            var removida = await _service.DeletarAsync(id);
            if (!removida)
                return NotFound(new { mensagem = $"Dica com ID {id} não encontrada." });

            return NoContent();
        }
    }
}
