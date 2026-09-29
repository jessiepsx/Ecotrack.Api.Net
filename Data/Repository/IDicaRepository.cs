using Ecotrack.Net.Models;

namespace Ecotrack.Api.Net.Data.Repository
{
    public interface IDicaRepository
    {
        Task<(IEnumerable<Dica> Items, int Total)> ListarAsync(int pagina, int itensPorPagina, CategoriaDica? categoria);
        Task<Dica?> BuscarPorIdAsync(int id);
        Task<Dica> CriarAsync(Dica dica);
        Task<Dica?> AtualizarAsync(int id, Dica dica);
        Task<bool> DeletarAsync(int id);
    }
}
