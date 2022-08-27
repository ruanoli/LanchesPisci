using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesPisci.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(200, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Nome")]
        public string? LancheNome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(500, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Pequena Descrição")]
        public string? DescricaoCurta { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(700, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Descrição Detalhada")]
        public string? DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Preço")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1, 9999.99, ErrorMessage ="Valor mínimo de 1 e máximo de 9999,99")]
        public decimal Preco { get; set; }
        [Display(Name = "Caminho imagem miniatura")]
        [StringLength(200, ErrorMessage ="Tamanho máximo de {1}")]
        public string? ImagemThembnailUrl { get; set; }
        [Display(Name = "Caminho imagem miniatura")]
        [StringLength(200, ErrorMessage = "Tamanho máximo de {1}")]
        public string? ImagemUrl { get; set; }
        [Display(Name = "Lanche Preferido?")]
        public bool IsLanchePreferido { get; set; }
        [Display(Name = "Em Estoque?")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
    }
}
