using Ecotrack.Api.Net.Data.Contexts;
using Ecotrack.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecotrack.Api.Net.Data.Repository
{
    public class DicaRepository : IDicaRepository
    {
        private readonly EcotrackContext _context;

        public DicaRepository(EcotrackContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Dica> Items, int Total)> ListarAsync(
            int pagina,
            int itensPorPagina,
            CategoriaDica? categoria)
        {
            var query = _context.Dicas
                .Where(d => d.Ativa == 1);

            if (categoria.HasValue)
            {
                query = query.Where(d => d.Categoria == categoria.Value);
            }

            var total = await query.CountAsync();

            var items = await query
                .OrderBy(d => d.Categoria)
                .ThenBy(d => d.Titulo)
                .Skip((pagina - 1) * itensPorPagina)
                .Take(itensPorPagina)
                .AsNoTracking()
                .ToListAsync();

            return (items, total);
        }

        public async Task<Dica?> BuscarPorIdAsync(int id)
        {
            return await _context.Dicas
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id && d.Ativa == 1);
        }

        public async Task<Dica> CriarAsync(Dica dica)
        {
            dica.DataCriacao = DateTime.UtcNow;
            dica.Ativa = 1;

            _context.Dicas.Add(dica);

            await _context.SaveChangesAsync();

            return dica;
        }

        public async Task<Dica?> AtualizarAsync(int id, Dica dicaAtualizada)
        {
            var dica = await _context.Dicas.FindAsync(id);

            if (dica == null || dica.Ativa == 0)
            {
                return null;
            }

            dica.Titulo = dicaAtualizada.Titulo;
            dica.Conteudo = dicaAtualizada.Conteudo;
            dica.Categoria = dicaAtualizada.Categoria;

            await _context.SaveChangesAsync();

            return dica;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var dica = await _context.Dicas.FindAsync(id);

            if (dica == null || dica.Ativa == 0)
            {
                return false;
            }

            // Soft Delete
            dica.Ativa = 0;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}