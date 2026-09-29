using Ecotrack.Api.Net.Data.Repository;
using Ecotrack.Api.Net.Models;

namespace Ecotrack.Api.Net.Services
{
    public class AcaoService : IAcaoService
    {
        private readonly IAcaoRepository _repository;

        public AcaoService(IAcaoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Acao> GetAll(int pagina, int tamanho)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public Acao? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Acao acao)
        {
            _repository.Add(acao);
        }

        public void Update(Acao acao)
        {
            _repository.Update(acao);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}