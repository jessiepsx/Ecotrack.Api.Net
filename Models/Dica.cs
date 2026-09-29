using System.ComponentModel.DataAnnotations;

namespace Ecotrack.Net.Models
{
    public class Dica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O título deve ter no máximo 150 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        [MaxLength(1000, ErrorMessage = "O conteúdo deve ter no máximo 1000 caracteres.")]
        public string Conteudo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public CategoriaDica Categoria { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public int Ativa { get; set; } = 1;
    }

    public enum CategoriaDica
    {
        ENERGIA,
        AGUA,
        RESIDUOS,
        MOBILIDADE,
        BIODIVERSIDADE,
        CONSUMO
    }
}
