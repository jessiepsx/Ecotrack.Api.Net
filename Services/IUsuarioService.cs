using Ecotrack.Net.Models;

namespace Ecotrack.Api.Net.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();

        IEnumerable<Usuario> GetAll(int page, int size);

        Usuario GetById(int id);

        void Add(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(int id);
    }
}
