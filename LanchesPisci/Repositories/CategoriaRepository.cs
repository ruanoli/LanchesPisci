using LanchesPisci.Context;
using LanchesPisci.Models;
using LanchesPisci.Repositories.Interface;

namespace LanchesPisci.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
