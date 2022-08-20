using LanchesPisci.Models;

namespace LanchesPisci.Repositories.Interface
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias {get;}
    }
}
