﻿using LanchesPisci.Repositories.Interface;
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

        public IActionResult List()
        {
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lancheListViewModel);
        }
    }
}
