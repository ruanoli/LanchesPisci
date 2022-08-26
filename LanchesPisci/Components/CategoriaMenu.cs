using LanchesPisci.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LanchesPisci.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoryRepository;
        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoryRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoryRepository.Categorias.OrderBy(x => x.CategoriaNome);
            return View(categorias);
        }
    }
}
