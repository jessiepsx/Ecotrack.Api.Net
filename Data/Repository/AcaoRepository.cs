using Ecotrack.Api.Net.Data.Contexts;
using Ecotrack.Api.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecotrack.Api.Net.Data.Repository
{
    public class AcaoRepository : IAcaoRepository
    {
        private readonly EcotrackContext _context;

        public AcaoRepository(EcotrackContext context)
        {
            _context = context;
        }

        public IEnumerable<Acao> GetAll(int pagina, int tamanho)
        {
            return _context.Acoes
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .AsNoTracking()
                .ToList();
        }

        public Acao? GetById(int id)
        {
            return _context.Acoes.Find(id);
        }

        public void Add(Acao acao)
        {
            _context.Acoes.Add(acao);
            _context.SaveChanges();
        }

        public void Update(Acao acao)
        {
            _context.Acoes.Update(acao);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var acao = _context.Acoes.Find(id);

            if (acao != null)
            {
                _context.Acoes.Remove(acao);
                _context.SaveChanges();
            }
        }
    }
}