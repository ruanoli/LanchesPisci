using System.ComponentModel.DataAnnotations;

namespace LanchesPisci.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o nome do Usuário.")]
        [Display(Name ="Usuário")]
        public string? UserName { get; set; }

        [Required(ErrorMessage ="Informe a senha.")]
        [DataType(DataType.Password)]
        [Display(Name ="Senha")]
        public string? Password { get; set; }

        public string? ReturnUrl { get; set; } //envia o usuário para a página que ele estava tentando acessar antes de logar.
    }
}
