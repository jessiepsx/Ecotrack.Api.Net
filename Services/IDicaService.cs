using Ecotrack.Api.Net.ViewModel;
using Ecotrack.Net.Models;

namespace Ecotrack.Api.Net.Services
{
    public interface IDicaService
    {
        Task<PagedResult<DicaViewModel>> ListarAsync(
            int pagina,
            int itensPorPagina,
            CategoriaDica? categoria);

        Task<DicaViewModel?> BuscarPorIdAsync(int id);

        Task<DicaViewModel> CriarAsync(
            DicaCreateViewModel viewModel);

        Task<DicaViewModel?> AtualizarAsync(
            int id,
            DicaCreateViewModel viewModel);

        Task<bool> DeletarAsync(int id);
    }
}