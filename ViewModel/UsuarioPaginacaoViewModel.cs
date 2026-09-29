using Ecotrack.Net.ViewModel;

namespace Ecotrack.Api.Net.ViewModel
{
    public class UsuarioPaginacaoViewModel
    {
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}