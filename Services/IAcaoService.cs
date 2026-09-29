using Ecotrack.Api.Net.Models;

namespace Ecotrack.Api.Net.Services
{
    public interface IAcaoService
    {
        IEnumerable<Acao> GetAll(int pagina, int tamanho);

        Acao? GetById(int id);

        void Add(Acao acao);

        void Update(Acao acao);

        void Delete(int id);
    }
}