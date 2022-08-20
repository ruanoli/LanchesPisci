using LanchesPisci.Context;
using LanchesPisci.Models;
using LanchesPisci.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LanchesPisci.Repository
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(x => x.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches
            .Where(x => x.IsLanchePreferido)
            .Include(x => x.Categoria);

        public Lanche GetLancheById(int lancheId) => _context.Lanches.FirstOrDefault(x => x.LancheId == lancheId);
    }
}
