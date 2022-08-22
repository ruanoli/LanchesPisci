using LanchesPisci.Models;

namespace LanchesPisci.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; } 
    }
}
