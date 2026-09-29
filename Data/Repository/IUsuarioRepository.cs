using Ecotrack.Net.Models;

namespace Ecotrack.Api.Net.Data.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();

        IEnumerable<Usuario> GetAll(int page, int size);

        Usuario GetById(int id);

        Usuario GetByEmail(string email);

        void Add(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(Usuario usuario);
    }
}

