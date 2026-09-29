using System.ComponentModel.DataAnnotations;
using Ecotrack.Net.Models;

namespace Ecotrack.Api.Net.ViewModel
{
    public class DicaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
    }

    public class DicaCreateViewModel
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O título deve ter no máximo 150 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        [MaxLength(1000, ErrorMessage = "O conteúdo deve ter no máximo 1000 caracteres.")]
        public string Conteudo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        [EnumDataType(typeof(CategoriaDica), ErrorMessage = "Categoria inválida. Use: ENERGIA, AGUA, RESIDUOS, MOBILIDADE, BIODIVERSIDADE ou CONSUMO.")]
        public CategoriaDica Categoria { get; set; }
    }

    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalItens { get; set; }
        public int ItensPorPagina { get; set; }
    }
}
