using System.ComponentModel.DataAnnotations;

namespace LanchesPisci.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(200,ErrorMessage = "Tamanho máximo de 200 caracteres.")]
        [Display(Name = "Categoria")]
        public string? CategoriaNome { get; set; }
        [StringLength(500, ErrorMessage = "Tamanho máximo de 200 caracteres.")]
        [Display(Name = "Categoria")]
        public string? Descricao { get; set; }

        public List<Lanche>? Lanches { get; set; }
    }
}
