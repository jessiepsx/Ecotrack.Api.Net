using Ecotrack.Api.Net.Data.Repository;
using Ecotrack.Api.Net.Services;
using Ecotrack.Net.Models;

namespace Ecotrack.Net.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Usuario> GetAll(int page, int size)
        {
            return _repository.GetAll(page, size);
        }

        public Usuario GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Usuario usuario)
        {
            _repository.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            _repository.Update(usuario);
        }

        public void Delete(int id)
        {
            var usuario = _repository.GetById(id);

            if (usuario != null)
            {
                _repository.Delete(usuario);
            }
        }
    }
}

