namespace Ecotrack.Api.Net.ViewModel
{
    public class AcaoViewModel
    {
        public long Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public int Pontos { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}