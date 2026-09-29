using Ecotrack.Api.Net.Data.Repository;
using Ecotrack.Api.Net.ViewModel;
using Ecotrack.Net.Models;

namespace Ecotrack.Api.Net.Services
{
    public class DicaService : IDicaService
    {
        private readonly IDicaRepository _repository;

        public DicaService(IDicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<DicaViewModel>> ListarAsync(
            int pagina,
            int itensPorPagina,
            CategoriaDica? categoria)
        {
            var (items, total) =
                await _repository.ListarAsync(
                    pagina,
                    itensPorPagina,
                    categoria);

            return new PagedResult<DicaViewModel>
            {
                Data = items.Select(d => new DicaViewModel
                {
                    Id = d.Id,
                    Titulo = d.Titulo,
                    Conteudo = d.Conteudo,
                    Categoria = d.Categoria.ToString(),
                    DataCriacao = d.DataCriacao
                }),

                PaginaAtual = pagina,
                ItensPorPagina = itensPorPagina,
                TotalItens = total,
                TotalPaginas =
                    (int)Math.Ceiling(
                        (double)total / itensPorPagina)
            };
        }

        public async Task<DicaViewModel?> BuscarPorIdAsync(int id)
        {
            var dica =
                await _repository.BuscarPorIdAsync(id);

            if (dica == null)
                return null;

            return new DicaViewModel
            {
                Id = dica.Id,
                Titulo = dica.Titulo,
                Conteudo = dica.Conteudo,
                Categoria = dica.Categoria.ToString(),
                DataCriacao = dica.DataCriacao
            };
        }

        public async Task<DicaViewModel> CriarAsync(
            DicaCreateViewModel viewModel)
        {
            var dica = new Dica
            {
                Titulo = viewModel.Titulo,
                Conteudo = viewModel.Conteudo,
                Categoria = viewModel.Categoria
            };

            dica =
                await _repository.CriarAsync(dica);

            return new DicaViewModel
            {
                Id = dica.Id,
                Titulo = dica.Titulo,
                Conteudo = dica.Conteudo,
                Categoria = dica.Categoria.ToString(),
                DataCriacao = dica.DataCriacao
            };
        }

        public async Task<DicaViewModel?> AtualizarAsync(
            int id,
            DicaCreateViewModel viewModel)
        {
            var dica = new Dica
            {
                Titulo = viewModel.Titulo,
                Conteudo = viewModel.Conteudo,
                Categoria = viewModel.Categoria
            };

            var atualizada =
                await _repository.AtualizarAsync(
                    id,
                    dica);

            if (atualizada == null)
                return null;

            return new DicaViewModel
            {
                Id = atualizada.Id,
                Titulo = atualizada.Titulo,
                Conteudo = atualizada.Conteudo,
                Categoria = atualizada.Categoria.ToString(),
                DataCriacao = atualizada.DataCriacao
            };
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await _repository.DeletarAsync(id);
        }
    }
}