using Ecotrack.Api.Net.Services;
using Ecotrack.Api.Net.ViewModel;
using Ecotrack.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecotrack.Net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get(
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanho = 10)
        {
            var usuarios = _service.GetAll(pagina, tamanho);

            foreach (var usuario in usuarios)
            {
                usuario.Senha = null;
            }

            return Ok(usuarios);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _service.GetById(id);

            if (usuario == null)
                return NotFound();

            usuario.Senha = null;

            return Ok(usuario);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioCreateViewModel viewModel)
        {
            var usuario = new Usuario
            {
                Nome = viewModel.Nome,
                Email = viewModel.Email,
                Senha = viewModel.Senha,
                Role = viewModel.Role
            };

            _service.Add(usuario);

            return CreatedAtAction(
                nameof(Get),
                new { id = usuario.Id },
                usuario);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(
            int id,
            [FromBody] UsuarioUpdateViewModel viewModel)
        {
            var usuario = _service.GetById(id);

            if (usuario == null)
                return NotFound();

            usuario.Nome = viewModel.Nome;
            usuario.Email = viewModel.Email;
            usuario.Role = viewModel.Role;

            _service.Update(usuario);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _service.GetById(id);

            if (usuario == null)
                return NotFound();

            _service.Delete(id);

            return NoContent();
        }
    }
}