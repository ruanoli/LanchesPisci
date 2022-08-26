using LanchesPisci.Models;
using LanchesPisci.Repositories.Interface;
using LanchesPisci.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesPisci.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(x => x.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                   lanches = _lancheRepository.Lanches
                        .Where(x => x.Categoria.CategoriaNome == "Normal")
                        .OrderBy(x => x.LancheNome);
                }
                else
                {
                   lanches = _lancheRepository.Lanches
                        .Where(x => x.Categoria.CategoriaNome == "Natural")
                        .OrderBy(x => x.LancheNome);
                }
                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(lancheListViewModel);
        }
    }
}
